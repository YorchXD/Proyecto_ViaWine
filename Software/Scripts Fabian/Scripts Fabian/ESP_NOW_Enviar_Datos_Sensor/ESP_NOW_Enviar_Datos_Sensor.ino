#include <esp_now.h>
#include <OneWire.h>
#include <DallasTemperature.h>
#include <WiFi.h>
#include <SoftwareSerial.h>
#include <TinyGPS.h>

#define LED_PIN 2
#define sensor 34

TinyGPS gps;
SoftwareSerial ss(16, 17);  //TX y RX

//static void smartdelay(unsigned long ms);

OneWire ourWire(15);                //Se establece el pin 2  como bus OneWire
DallasTemperature sensors(&ourWire); //Se declara una variable u objeto para nuestro sensor

DeviceAddress address1 = {0x28, 0xAA, 0xA6, 0xA1, 0x13, 0x13, 0x1, 0x4D};//dirección del sensor 1
DeviceAddress address2 = {0x28, 0xAA, 0xD2, 0x38, 0x13, 0x13, 0x2, 0xAF};//dirección del sensor 2


unsigned long previousMillis = 0;

// Global copy of slave
#define NUMSLAVES 20
esp_now_peer_info_t slaves[NUMSLAVES] = {};
int SlaveCnt = 0, i=0;

#define CHANNEL_MASTER 9
#define CHANNEL_SLAVE 9
#define PRINTSCANRESULTS 0
#define DATASIZE 48

// Init ESP Now with fallback
void InitESPNow() {
  if (esp_now_init() == ESP_OK) {
    Serial.println("ESPNow Init Success");
  }
  else {
    Serial.println("ESPNow Init Failed");
    // Retry InitESPNow, add a counte and then restart?
    // InitESPNow();
    // or Simply Restart
    ESP.restart();
  }
}

// Scan for slaves in AP mode
void ScanForSlave() {
  int8_t scanResults = WiFi.scanNetworks();
  //reset slaves
  memset(slaves, 0, sizeof(slaves));
  SlaveCnt = 0;
  Serial.println("");
  if (scanResults == 0) {
    Serial.println("No WiFi devices in AP Mode found");
  } else {
    Serial.print("Found "); Serial.print(scanResults); Serial.println(" devices ");
    for (int i = 0; i < scanResults; ++i) {
      // Print SSID and RSSI for each device found
      String SSID = WiFi.SSID(i);
      int32_t RSSI = WiFi.RSSI(i);
      String BSSIDstr = WiFi.BSSIDstr(i);

      if (PRINTSCANRESULTS) {
        Serial.print(i + 1); Serial.print(": "); Serial.print(SSID); Serial.print(" ["); Serial.print(BSSIDstr); Serial.print("]"); Serial.print(" ("); Serial.print(RSSI); Serial.print(")"); Serial.println("");
      }
      delay(10);
      // Check if the current device starts with `Slave`
      if (SSID.indexOf("ESPNOW") == 0) {
        // SSID of interest
        Serial.print(i + 1); Serial.print(": "); Serial.print(SSID); Serial.print(" ["); Serial.print(BSSIDstr); Serial.print("]"); Serial.print(" ("); Serial.print(RSSI); Serial.print(")"); Serial.println("");
        // Get BSSID => Mac Address of the Slave
        int mac[6];

        if ( 6 == sscanf(BSSIDstr.c_str(), "%02x:%02x:%02x:%02x:%02x:%02x",  &mac[0], &mac[1], &mac[2], &mac[3], &mac[4], &mac[5] ) ) {
          for (int ii = 0; ii < 6; ++ii ) {
            slaves[SlaveCnt].peer_addr[ii] = (uint8_t) mac[ii];
          }
        }
        slaves[SlaveCnt].channel = CHANNEL_MASTER; // pick a channel
        slaves[SlaveCnt].encrypt = 0; // no encryption
        SlaveCnt++;
      }
    }
  }

  if (SlaveCnt > 0) {
    Serial.print(SlaveCnt); Serial.println(" Slave(s) found, processing..");
  } else {
    Serial.println("No Slave Found, trying again.");
  }

  // clean up ram
  WiFi.scanDelete();
}

// Check if the slave is already paired with the master.
// If not, pair the slave with master
void manageSlave() {
  if (SlaveCnt > 0) {
    for (int i = 0; i < SlaveCnt; i++) {
      const esp_now_peer_info_t *peer = &slaves[i];
      const uint8_t *peer_addr = slaves[i].peer_addr;
      Serial.print("Processing: ");
      for (int ii = 0; ii < 6; ++ii ) {
        Serial.print((uint8_t) slaves[i].peer_addr[ii], HEX);
        if (ii != 5) Serial.print(":");
      }
      Serial.print(" Status: ");
      // check if the peer exists
      bool exists = esp_now_is_peer_exist(peer_addr);
      if (exists) {
        // Slave already paired.
        Serial.println("Already Paired");
      } else {
        // Slave not paired, attempt pair
        esp_err_t addStatus = esp_now_add_peer(peer);
        if (addStatus == ESP_OK) {
          // Pair success
          Serial.println("Pair success");
        } else if (addStatus == ESP_ERR_ESPNOW_NOT_INIT) {
          // How did we get so far!!
          Serial.println("ESPNOW Not Init");
        } else if (addStatus == ESP_ERR_ESPNOW_ARG) {
          Serial.println("Add Peer - Invalid Argument");
        } else if (addStatus == ESP_ERR_ESPNOW_FULL) {
          Serial.println("Peer list full");
        } else if (addStatus == ESP_ERR_ESPNOW_NO_MEM) {
          Serial.println("Out of memory");
        } else if (addStatus == ESP_ERR_ESPNOW_EXIST) {
          Serial.println("Peer Exists");
        } else {
          Serial.println("Not sure what happened");
        }
        delay(100);
      }
    }
  } else {
    // No slave found to process
    Serial.println("No Slave found to process");
  }
}

uint8_t data[DATASIZE];
uint32_t pos=0;
float TSF=0;
float TSS=0;
float HMD=0;
float FLAT=0;
float FLON=0;
//float ILAT=0;
//float ILON=0;
uint64_t ID_NODO;
uint64_t Temperatura_Superficie;
uint64_t Temperatura_Subsuelo;
uint64_t Humedad;
uint64_t Latitud;
uint64_t Longitud;


// Mac Address of the peer to which we will send the data
uint8_t peerMacAddress[] = {0x24, 0x0A, 0xC4, 0xC6, 0x0B, 0xE9};
//NODO1 Envía datos sensor 
//24:0a:c4:c6:0b:e9 NODO RECEPTOR
//3c:71:bf:d0:70:90 NODO INFORMANTE 1

// send data
void sendData_ID_NODO() {
  digitalWrite(LED_PIN, 1);
  uint64_t ID_NODO= 1;
  sprintf((char *)data,"%lld",ID_NODO);  
  
  for (int i = 0; i < SlaveCnt; i++) {
    const uint8_t *peer_addr = slaves[i].peer_addr;
    if (i == 0) { // print only for first slave
      Serial.print("Sending: ");
      Serial.println((char *)data);
    }
    esp_err_t result = esp_now_send(peer_addr, data, DATASIZE);
    Serial.print("Send Status: ");
    if (result == ESP_OK) {
      Serial.println("Success");
    } else if (result == ESP_ERR_ESPNOW_NOT_INIT) {
      // How did we get so far!!
      Serial.println("ESPNOW not Init.");
    } else if (result == ESP_ERR_ESPNOW_ARG) {
      Serial.println("Invalid Argument");
    } else if (result == ESP_ERR_ESPNOW_INTERNAL) {
      Serial.println("Internal Error");
    } else if (result == ESP_ERR_ESPNOW_NO_MEM) {
      Serial.println("ESP_ERR_ESPNOW_NO_MEM");
    } else if (result == ESP_ERR_ESPNOW_NOT_FOUND) {
      Serial.println("Peer not found.");
    } else {
      Serial.println("Not sure what happened");
    }
    delay(100);
    digitalWrite(LED_PIN, 0);
  }
}

void sendData_TSF() {
//  pos++;
  //sprintf((char *)data,"%lld",pos);
  digitalWrite(LED_PIN, 1);
  uint64_t Temperatura_Superficie=TSF*100;
  sprintf((char *)data,"%lld",Temperatura_Superficie);
  //sprintf((char *)data,"%lld",Temperatura_Subsuelo);
  //sprintf((char *)data,"%lld",Humedad);
  
  
  for (int i = 0; i < SlaveCnt; i++) {
    const uint8_t *peer_addr = slaves[i].peer_addr;
    if (i == 0) { // print only for first slave
      Serial.print("Sending: ");
      Serial.println((char *)data);
    }
    esp_err_t result = esp_now_send(peer_addr, data, DATASIZE);
    Serial.print("Send Status: ");
    if (result == ESP_OK) {
      Serial.println("Success");
    } else if (result == ESP_ERR_ESPNOW_NOT_INIT) {
      // How did we get so far!!
      Serial.println("ESPNOW not Init.");
    } else if (result == ESP_ERR_ESPNOW_ARG) {
      Serial.println("Invalid Argument");
    } else if (result == ESP_ERR_ESPNOW_INTERNAL) {
      Serial.println("Internal Error");
    } else if (result == ESP_ERR_ESPNOW_NO_MEM) {
      Serial.println("ESP_ERR_ESPNOW_NO_MEM");
    } else if (result == ESP_ERR_ESPNOW_NOT_FOUND) {
      Serial.println("Peer not found.");
    } else {
      Serial.println("Not sure what happened");
    }
    delay(100);
    digitalWrite(LED_PIN, 0);
  }
}

void sendData_TSS() {
//  pos++;
  //sprintf((char *)data,"%lld",pos);
  digitalWrite(LED_PIN, 1);

  uint64_t Temperatura_Subsuelo=TSS*100;
  sprintf((char *)data,"%lld",Temperatura_Subsuelo);
  //sprintf((char *)data,"%lld",Humedad);
  
  
  for (int i = 0; i < SlaveCnt; i++) {
    const uint8_t *peer_addr = slaves[i].peer_addr;
    if (i == 0) { // print only for first slave
      Serial.print("Sending: ");
      Serial.println((char *)data);
    }
    esp_err_t result = esp_now_send(peer_addr, data, DATASIZE);
    Serial.print("Send Status: ");
    if (result == ESP_OK) {
      Serial.println("Success");
    } else if (result == ESP_ERR_ESPNOW_NOT_INIT) {
      // How did we get so far!!
      Serial.println("ESPNOW not Init.");
    } else if (result == ESP_ERR_ESPNOW_ARG) {
      Serial.println("Invalid Argument");
    } else if (result == ESP_ERR_ESPNOW_INTERNAL) {
      Serial.println("Internal Error");
    } else if (result == ESP_ERR_ESPNOW_NO_MEM) {
      Serial.println("ESP_ERR_ESPNOW_NO_MEM");
    } else if (result == ESP_ERR_ESPNOW_NOT_FOUND) {
      Serial.println("Peer not found.");
    } else {
      Serial.println("Not sure what happened");
    }
    delay(100);
    digitalWrite(LED_PIN, 0);
  }
}

void sendData_HMD() {
  digitalWrite(LED_PIN, 1);
  uint64_t Humedad=HMD*100;
  sprintf((char *)data,"%lld",Humedad);
  
 
  for (int i = 0; i < SlaveCnt; i++) {
    
    const uint8_t *peer_addr = slaves[i].peer_addr;
    if (i == 0) { // print only for first slave
      Serial.print("Sending: ");
      Serial.println((char *)data);
    }
    esp_err_t result = esp_now_send(peer_addr, data, DATASIZE);
    Serial.print("Send Status: ");
    if (result == ESP_OK) {
      Serial.println("Success");
    } else if (result == ESP_ERR_ESPNOW_NOT_INIT) {
      // How did we get so far!!
      Serial.println("ESPNOW not Init.");
    } else if (result == ESP_ERR_ESPNOW_ARG) {
      Serial.println("Invalid Argument");
    } else if (result == ESP_ERR_ESPNOW_INTERNAL) {
      Serial.println("Internal Error");
    } else if (result == ESP_ERR_ESPNOW_NO_MEM) {
      Serial.println("ESP_ERR_ESPNOW_NO_MEM");
    } else if (result == ESP_ERR_ESPNOW_NOT_FOUND) {
      Serial.println("Peer not found.");
    } else {
      Serial.println("Not sure what happened");
    }

    delay(100);  
    digitalWrite(LED_PIN, 0);
  }
}

void sendData_GPS_LAT() {
  digitalWrite(LED_PIN, 1);
  uint64_t Latitud=FLAT*1000000;
  //*1000000
  sprintf((char *)data,"%lld",Latitud);
  
 
  for (int i = 0; i < SlaveCnt; i++) {
    
    const uint8_t *peer_addr = slaves[i].peer_addr;
    if (i == 0) { // print only for first slave
      Serial.print("Sending: ");
      Serial.println((char *)data);
    }
    esp_err_t result = esp_now_send(peer_addr, data, DATASIZE);
    Serial.print("Send Status: ");
    if (result == ESP_OK) {
      Serial.println("Success");
    } else if (result == ESP_ERR_ESPNOW_NOT_INIT) {
      // How did we get so far!!
      Serial.println("ESPNOW not Init.");
    } else if (result == ESP_ERR_ESPNOW_ARG) {
      Serial.println("Invalid Argument");
    } else if (result == ESP_ERR_ESPNOW_INTERNAL) {
      Serial.println("Internal Error");
    } else if (result == ESP_ERR_ESPNOW_NO_MEM) {
      Serial.println("ESP_ERR_ESPNOW_NO_MEM");
    } else if (result == ESP_ERR_ESPNOW_NOT_FOUND) {
      Serial.println("Peer not found.");
    } else {
      Serial.println("Not sure what happened");
    }

    delay(100);
    digitalWrite(LED_PIN, 0); 
  }
}

void sendData_GPS_LON() {
  digitalWrite(LED_PIN, 1);
  //uint64_t Longitud=ILON;
  uint64_t Longitud=FLON*1000000;
  //*1000000;
  sprintf((char *)data,"%lld",Longitud);
  
 
  for (int i = 0; i < SlaveCnt; i++) {
    
    const uint8_t *peer_addr = slaves[i].peer_addr;
    if (i == 0) { // print only for first slave
      Serial.print("Sending: ");
      Serial.println((char *)data);
    }
    esp_err_t result = esp_now_send(peer_addr, data, DATASIZE);
    Serial.print("Send Status: ");
    if (result == ESP_OK) {
      Serial.println("Success");
    } else if (result == ESP_ERR_ESPNOW_NOT_INIT) {
      // How did we get so far!!
      Serial.println("ESPNOW not Init.");
    } else if (result == ESP_ERR_ESPNOW_ARG) {
      Serial.println("Invalid Argument");
    } else if (result == ESP_ERR_ESPNOW_INTERNAL) {
      Serial.println("Internal Error");
    } else if (result == ESP_ERR_ESPNOW_NO_MEM) {
      Serial.println("ESP_ERR_ESPNOW_NO_MEM");
    } else if (result == ESP_ERR_ESPNOW_NOT_FOUND) {
      Serial.println("Peer not found.");
    } else {
      Serial.println("Not sure what happened");
    }

    delay(10);
    digitalWrite(LED_PIN, 0);
    //delay(10000-10);
    delay(5000-10);
    Serial.println();
    
  }
}

// callback when data is sent from Master to Slave
void OnDataSent(const uint8_t *mac_addr, esp_now_send_status_t status) {
  char macStr[18];
  snprintf(macStr, sizeof(macStr), "%02x:%02x:%02x:%02x:%02x:%02x",
           mac_addr[0], mac_addr[1], mac_addr[2], mac_addr[3], mac_addr[4], mac_addr[5]);
  Serial.print("Last Packet Sent to: "); Serial.println(macStr);
  Serial.print("Last Packet Send Status: "); Serial.println(status == ESP_NOW_SEND_SUCCESS ? "Delivery Success" : "Delivery Fail");
}

// callback when data is recv from Master
void OnDataRecv(const uint8_t *mac_addr, const uint8_t *data, int data_len) {
  char macStr[18];
  
  snprintf(macStr, sizeof(macStr), "%02x:%02x:%02x:%02x:%02x:%02x",
           mac_addr[0], mac_addr[1], mac_addr[2], mac_addr[3], mac_addr[4], mac_addr[5]);
  Serial.print("\t\tLast Packet Recv from: "); Serial.println(macStr);
  Serial.print("\t\tLast Packet Recv Data: "); Serial.println((char *)data);
  Serial.println("");
  delay(10); // just a little bit
  digitalWrite(LED_PIN, 0);
}

// config AP SSID
void configDeviceAP() {
  String Prefix = "ESPNOW:";
  String Mac = WiFi.macAddress();
  String SSID = Prefix + Mac;
  String Password = "123456789";
  bool result = WiFi.softAP(SSID.c_str(), Password.c_str(), CHANNEL_SLAVE, 0);
  if (!result) {
    Serial.println("AP Config failed.");
  } else {
    Serial.println("AP Config Success. Broadcasting with AP: " + String(SSID));
  }
}

void setup() {
  Serial.begin(115200);
  //ss.begin(9600);
  pinMode(sensor, INPUT);
  pinMode(LED_PIN, OUTPUT);
  //Set device in STA mode to begin with
  WiFi.mode(WIFI_MODE_APSTA);
  Serial.println("ESPNow/Multi-Slave/Master Example");
  // configure device AP mode
  configDeviceAP();
  // This is the mac address of the Master in Station Mode
  Serial.print("STA MAC: "); Serial.println(WiFi.macAddress());
  Serial.print("AP MAC: "); Serial.println(WiFi.softAPmacAddress());
  // Init ESPNow with a fallback logic
  InitESPNow();
  // Once ESPNow is successfully Init, we will register for Send CB to
  // get the status of Trasnmitted packet
  ss.begin(9600);
  esp_now_register_send_cb(OnDataSent);
  //esp_now_register_recv_cb(OnDataRecv);
}

void loop() {
  //delay(10000);
  smartdelay(2000);
  //float FLAT, FLON;
  unsigned long currentMillis = millis();
  //Se hace la lectura analoga del pin A0 (sensor) y se pasa por la funcion
  //map() para ajustar los valores leidos a los porcentajes que queremos utilizar   
  HMD = map(analogRead(sensor), 4095, 0, 0, 100);
  gps.f_get_position(&FLAT, &FLON);//lee latitud y longitud GPS
  sensors.requestTemperatures();   //envía el comando para obtener las temperaturas
  float temp1= sensors.getTempC(address1);//Se obtiene la temperatura en °C del sensor 1
  TSF=temp1;
  float temp2= sensors.getTempC(address2);//Se obtiene la temperatura en °C del sensor 2
  TSS=temp2;

  //int ILAT = FLAT*1000000;
  //int ILON = FLON*1000000;
  
  Serial.print("HMD= ");
  Serial.println(HMD);
  Serial.print("TSF= ");
  Serial.println(TSF);
  Serial.print("TSS= ");
  Serial.println(TSS);  
  Serial.print("FLAT= ");
  Serial.println(FLAT,10);
  Serial.print("FLON= ");
  Serial.println(FLON,10);
  //delay(5000);
  
  // In the loop we scan for slave
  ScanForSlave();
  // If Slave is found, it would be populate in `slave` variable
  // We will check if `slave` is defined and then we proceed further
  if (SlaveCnt > 0) { // check if slave channel is defined
    // `slave` is defined
    // Add slave as peer if it has not been added already
    manageSlave();
    // pair success or already paired
    // Send data to device
    sendData_ID_NODO(); //Identificador_Nodo
    sendData_TSF();  //Temperatura_Superficie
    sendData_TSS();  //Temperatura_Subsuelo
    sendData_HMD();  //Humedad
    sendData_GPS_LAT();  //GPS_Latitud
    sendData_GPS_LON();  //GPS_Longitud
  } else {
    // No slave found to process
  }

  // wait for 3seconds to run the logic again
  //delay(2000);
}

static void smartdelay(unsigned long ms)
{
  unsigned long start = millis();
  do 
  {
    while (ss.available())
      gps.encode(ss.read());
  } while (millis() - start < ms);
}
