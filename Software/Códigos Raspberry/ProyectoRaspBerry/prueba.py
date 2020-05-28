import time
import pyodbc
from datetime import datetime
from Botella import Botella
import datetime as dt

conn = pyodbc.connect('Driver={ODBC Driver 17 for SQL Server};SERVER=190.171.160.83;PORT=1433;DATABASE=Automatizacion_ViaWines2.0;UID=sa;PWD=J1h4m3b012*;TDS_Version=4.2;')

cursor = conn.cursor()
primeraBotella = None
ultimaBotella = None

cursor.execute("SELECT TOP 1 * FROM botellas WHERE refOrdenPlan = '58'")
for row in cursor.fetchall():
    primeraBotella = Botella(row[0], row[1], row[2], row[4], row[3])
    primeraBotella.imprimir()
    print(primeraBotella.getHoraTermino())

delta = dt.timedelta(seconds = 60)
print((dt.datetime.combine(dt.date(1,1,1),primeraBotella.getHoraTermino()) + delta).time())



#intervalo = (primeraBotella.getHoraTermino() + datetime.timedelta(seconds=60)).time()
#print(type(intervalo))
#print(intervalo.second)  

cursor.execute("SELECT TOP 1 * FROM botellas WHERE refOrdenPlan = '58' ORDER BY id DESC")
for row in cursor.fetchall():
    ultimaBotella = Botella(row[0], row[1], row[2], row[4], row[3])
    ultimaBotella.imprimir()
    
cursor.execute("SELECT COUNT(*) FROM botellas WHERE refOrdenPlan = '58'")
for row in cursor.fetchall():
    print(str(row[0]))
    
cursor.close()