void setup() {
  // put your setup code here, to run once:
pinMode(10,OUTPUT);
pinMode(7,OUTPUT);
pinMode(6,OUTPUT);
pinMode(5,OUTPUT);
pinMode(4,OUTPUT);
pinMode(3,OUTPUT);
pinMode(2,OUTPUT);
pinMode(8,OUTPUT);
pinMode(9,OUTPUT);

Serial.begin(9600);

}


void loop() 
{
  // put your main code here, to run repeatedly:
if (Serial.available())
{
  int gelenVeri= Serial.read();

     if(gelenVeri=='0')
      {
        digitalWrite(2,LOW);
        digitalWrite(3,LOW);
        digitalWrite(4,LOW);
        digitalWrite(5,LOW);
        digitalWrite(6,LOW);
        digitalWrite(7,LOW);
        digitalWrite(8,LOW);
        digitalWrite(9,LOW);
        digitalWrite(10,LOW); 
      }

    else if(gelenVeri=='2')
      {
        digitalWrite(2,HIGH);
         digitalWrite(3,LOW);
        digitalWrite(4,LOW);
        digitalWrite(5,LOW);
        digitalWrite(6,LOW);
        digitalWrite(7,LOW);
        digitalWrite(8,LOW);
        digitalWrite(9,LOW);
        digitalWrite(10,LOW); 
       
        }

    else if(gelenVeri=='3')
      {
        digitalWrite(3,HIGH);
        digitalWrite(2,LOW);
        digitalWrite(4,LOW);
        digitalWrite(5,LOW);
        digitalWrite(6,LOW);
        digitalWrite(7,LOW);
        digitalWrite(8,LOW);
        digitalWrite(9,LOW);
        digitalWrite(10,LOW); 
        }

    else if(gelenVeri=='4')
      {
        digitalWrite(4,HIGH);
     digitalWrite(3,LOW);
        digitalWrite(2,LOW);
        digitalWrite(5,LOW);
        digitalWrite(6,LOW);
        digitalWrite(7,LOW);
        digitalWrite(8,LOW);
        digitalWrite(9,LOW);
        digitalWrite(10,LOW); 
        }
    else if(gelenVeri=='5')
      {
        digitalWrite(5,HIGH);
         digitalWrite(3,LOW);
        digitalWrite(4,LOW);
        digitalWrite(2,LOW);
        digitalWrite(6,LOW);
        digitalWrite(7,LOW);
        digitalWrite(8,LOW);
        digitalWrite(9,LOW);
        digitalWrite(10,LOW); 
        }
     else if(gelenVeri=='6')
      {
        digitalWrite(6,HIGH);
        digitalWrite(3,LOW);
        digitalWrite(4,LOW);
        digitalWrite(5,LOW);
        digitalWrite(2,LOW);
        digitalWrite(7,LOW);
        digitalWrite(8,LOW);
        digitalWrite(9,LOW);
        digitalWrite(10,LOW); 
        }
     else if(gelenVeri=='7')
      {
        digitalWrite(7,HIGH);
         digitalWrite(3,LOW);
        digitalWrite(4,LOW);
        digitalWrite(5,LOW);
        digitalWrite(6,LOW);
        digitalWrite(2,LOW);
        digitalWrite(11,LOW);
        digitalWrite(12,LOW);
        digitalWrite(13,LOW); 
        }
     else if(gelenVeri=='8')
      {
        digitalWrite(8,HIGH);
        digitalWrite(3,LOW);
        digitalWrite(4,LOW);
        digitalWrite(5,LOW);
        digitalWrite(6,LOW);
        digitalWrite(7,LOW);
        digitalWrite(2,LOW);
        digitalWrite(9,LOW);
        digitalWrite(10,LOW); 
        }
     else if(gelenVeri=='9')
      {
        digitalWrite(9,HIGH);
       digitalWrite(3,LOW);
        digitalWrite(4,LOW);
        digitalWrite(5,LOW);
        digitalWrite(6,LOW);
        digitalWrite(7,LOW);
        digitalWrite(8,LOW);
        digitalWrite(2,LOW);
        digitalWrite(13,LOW); 
        }
     else if(gelenVeri=='10')
      {
        digitalWrite(10,HIGH);
        digitalWrite(3,LOW);
        digitalWrite(4,LOW);
        digitalWrite(5,LOW);
        digitalWrite(6,LOW);
        digitalWrite(7,LOW);
        digitalWrite(8,LOW);
        digitalWrite(9,LOW);
        digitalWrite(2,LOW); 
        }
  }
}
