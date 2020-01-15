
#define Entrada 8
#define Salida  9
#define Cajas   10

  int cant = 0;
  unsigned long tiempo1 = 0;
  unsigned long tiempo2 = 0;
  unsigned long tiempoSegundos = 0;


void setup(){
  
  Serial.begin(9600);
  
  pinMode(Entrada, INPUT);
  pinMode(Salida,  INPUT);
  pinMode(Cajas,   INPUT);

  tiempo1 = millis();
  
}
 
void loop(){
  
  int entrada= digitalRead(Entrada);
  int salida = digitalRead(Salida);
  int cajas  = digitalRead(cajas);

  int contador_botellas_1 = 0;
  int contador_botellas_2 = 0;
  int contador_cajas   = 0;
  
  int botella1 = 0;
  int botella2 = 0;
  int caja    = 0;
  int i,j;
  //float velocidad;
          



//***Generador random para simular que pasan botellas***

       while(cant<1){
       tiempo2 = millis();
       
          if(tiempo2 > (tiempo1+1000)){  //Si ha pasado 1 segundo ejecuta el IF
          tiempo1 = millis(); //Actualiza el tiempo actual
          tiempoSegundos = tiempo1/1000;
                }


//**** BOTELLAS QUE ENTRAN ****
         
        botella1=random(0,100);
        
        if(botella1>=0){
          contador_botellas_1++;
          Serial.println("***************************");
          Serial.print("Botellas que Entran: ");
          Serial.print(contador_botellas_1);
          Serial.print('\n');
          delay(random(80,120));
        }
        
        else{   
          Serial.println("***************************");
          Serial.println("No detecta S1");
          delay(random(80,120));
        }


//**** BOTELLAS QUE SALEN ****

        botella2=random(0,100);
    
        if(botella2>=10){
          contador_botellas_2++;
          Serial.println("***************************");
          Serial.print("Botellas que Salen: ");
          Serial.print(contador_botellas_2);
          Serial.print('\n');
          delay(random(80,120));
        }
        
        else{   
          Serial.println("***************************");
          Serial.println("No detecta S2 ");
          delay(random(80,120));
        }


//**** CONTEO DE CAJAS ****
      
        caja=random(0,100);
    
        if(caja>=50){
          contador_cajas++;
          Serial.println("***************************");
          Serial.print("Conteo de Cajas: ");
          Serial.print(contador_cajas);
          Serial.print('\n');
          delay(random(80,120));
        }
        
        else{   
          Serial.println("***************************");
          Serial.println("No detecta S3 ");
          delay(random(80,120));
        }

        if(contador_cajas==10) {
          float velocidad = 10/3;
          Serial.println("***************************");
          Serial.println("***************************");
          Serial.println("***************************");
          Serial.print("Cajas: ");
          Serial.println(contador_cajas);
          Serial.print("Botellas que entran: ");
          Serial.println(contador_botellas_1);
          Serial.print("Botellas que salen: ");
          Serial.println(contador_botellas_2);
          Serial.print("Tiempo transcurrido: ");
          Serial.print(tiempoSegundos);
          Serial.println(" segundos");

          Serial.print("Velocidad de producción: ");
          Serial.print(5,4);
          Serial.println(" cajas / segundo");
        }
        //}
        
        if(contador_cajas==10) cant++;
       
       }
       
     
////*** FIN Generador random para simular que pasan botellas***


}
