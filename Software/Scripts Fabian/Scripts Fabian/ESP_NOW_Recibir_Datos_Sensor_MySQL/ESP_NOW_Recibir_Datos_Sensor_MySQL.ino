#include <esp_now.h>
#include <WiFi.h>


//-------------------VARIABLES GLOBALES--------------------------

#define LED_PIN 2
int contconexion = 0;
//const char *ssid = "Tibox_Piso2";
//const char *password = "J1h4m3b012";

const char *ssid = ".: Tibox Chile :.";
const char *password = "Tiboxchile324341*";


//const char *ssid = "Ardu";
//const char *password = "ardu1456";

//const char *ssid = "Casa";
//const char *password = "1157549$$";


//const char *ssid = "TBX 4";
//const char *password = "tiboxchile324341";


#define CHANNEL_MASTER 9
#define CHANNEL_SLAVE 9
#define PRINTSCANRESULTS 0
#define DATASIZE 48

int says = 0;
int aux = 0;
int i = 0;
char host[48];
//NODO_INFORMANTE_1 = "3c:71:bf:d0:70:90";

WiFiClient client;
char server[] = "10.10.0.115";
IPAddress ip(10, 10, 0, 134);

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

uint8_t data[DATASIZE];
//uint64_t pos=0;// callback when data is recv from Master

int ID_NODO = 0;
float Temperatura_Superficie = 0;
float Temperatura_Subsuelo = 0;
float Humedad = 0;
double Latitud = 0;
double Longitud = 0;
//INFORMANTE_1="3c:71:bf:d0:70:90";


void OnDataRecv(const uint8_t *mac_addr, const uint8_t *data, int data_len) {
  char macStr[18];
  i++;
  if (i == 1) {
    ID_NODO = (atoi((char *)data));
    Serial.print("ID_NODO = ");
    Serial.println(ID_NODO);
  }
  
  if (i == 2) {
    Temperatura_Superficie = (atoi((char *)data)) * 0.01;

    Serial.print("Temperatura_Superficie = ");
    //Serial.println((char *)data);
    Serial.println(Temperatura_Superficie);
  }
  if (i == 3) {
    Temperatura_Subsuelo = (atoi((char *)data)) * 0.01;
    Serial.print("Temperatura_Subsuelo = ");
    //Serial.println((char *)data);
    Serial.println(Temperatura_Subsuelo);
  }
  if (i == 4) {
    Humedad = (atoi((char *)data) * 0.01);
    Serial.print("Humedad = ");
    //Serial.println((char *)data);
    Serial.println(Humedad);

  }
  if (i == 5) {
    Latitud = (atoi((char *)data)) * 0.000001;
    Serial.print("Latitud = ");
    //Serial.println((char *)data);
    Serial.println(Latitud, 6);
  }
  if (i == 6) {
    Longitud = (atoi((char *)data)) * 0.000001;
    Serial.print("Longitud = ");
    //Serial.println((char *)data);
    Serial.println(Longitud, 6);
    i = 0;
    Serial.println();
  }

  digitalWrite(LED_PIN, 1);
  snprintf(macStr, sizeof(macStr), "%02x:%02x:%02x:%02x:%02x:%02x",
           mac_addr[0], mac_addr[1], mac_addr[2], mac_addr[3], mac_addr[4], mac_addr[5]);



  Serial.print("\t\tLast Packet Recv from: "); Serial.println(macStr);
  Serial.print("\t\tLast Packet Recv Data: "); Serial.println((char *)data);
  Serial.println("");
  delay(10); // just a little bit
  digitalWrite(LED_PIN, 0);
  //Sending_To_phpmyadmindatabase();

  
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


//-------Función para Enviar Datos a la Base de Datos SQL--------



//-------------------------------------------------------------------------

void setup() {

  // Inicia Serial
  Serial.begin(115200);
  WIFI();
  // ConnectWiFi_STA;
  pinMode(LED_PIN, OUTPUT);

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
  // esp_now_register_send_cb(OnDataSent);
  esp_now_register_recv_cb(OnDataRecv);
}

void WIFI() {
  WiFi.begin(ssid, password);
  while (WiFi.status() != WL_CONNECTED and contconexion < 50) { //Cuenta hasta 50 si no se puede conectar lo cancela
    ++contconexion;
    delay(500);
    Serial.print(".");
  }
  if (contconexion < 50) {
    //para usar con ip fija

    Serial.println("");
    Serial.println("WiFi conectado!");
    Serial.println(WiFi.localIP());
  }
  else {
    Serial.println("");
    Serial.println("Error de conexion");
  }
  delay(1000);
}


//--------------------------LOOP--------------------------------
void loop() {
  //delay(10000);
  //says++;
  // WIFI();
  /*if (aux==0) delay(5000); aux++;
    Serial.println("Enviando says to DB...");
    Sending_To_phpmyadmindatabase();
  */
  if (ID_NODO !=0){
  
    Sending_To_phpmyadmindatabase();
  }
  
  delay(10000);

}

void Sending_To_phpmyadmindatabase()
{
  if (client.connect(server, 80)) {
    Serial.println("connected");
    //Make a HTTP request:
    Serial.print("GET /testcode/dht.php?ID_NODO=");
    client.print("GET /testcode/dht.php?ID_NODO="); //YOUR URL
    Serial.println(ID_NODO);
    client.print(ID_NODO);
    client.print("&Temperatura_Superficie=");
    Serial.println("&Temperatura_Superficie=");
    Serial.println(Temperatura_Superficie);
    client.print(Temperatura_Superficie);
    client.print("&Temperatura_Subsuelo=");
    Serial.println("&Temperatura_Subsuelo=");
    client.print(Temperatura_Subsuelo);
    Serial.println(Temperatura_Subsuelo);
    client.print("&Humedad=");
    Serial.println("&Humedad=");
    client.print(Humedad);
    Serial.println(Humedad);
    client.print("&Latitud=");
    Serial.println("&Latitud=");
    client.print(Latitud,6);
    Serial.println(Latitud,6);
    client.print("&Longitud=");
    Serial.println("&Longitud=");
    client.print(Longitud,6);
    Serial.println(Longitud,6);
    client.print(" ");  //SPACE BEFORE HTTP/1.1
    client.print("HTTP/1.1");
    client.println();
    client.println("Host: 10.10.0.112");
    client.println("Connection: close");
    client.println();
  } else {
    //if you didn't get a connection to the server:
    Serial.println("connection failed");
  }
}
