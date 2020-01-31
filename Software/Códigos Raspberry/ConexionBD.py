# -*- coding: utf-8 -*-
"""
Created on Fri Jan 31 16:07:26 2020

@author: YorchXD
"""

import pyodbc
direccion_servidor = '190.171.160.84'
nombre_bd = 'bd_100'
nombre_usuario = 'sapnew'
password = 'Via2018'
try:
    conexion = pyodbc.connect('DRIVER={ODBC Driver 17 for SQL Server};SERVER=' +
                              direccion_servidor+';DATABASE='+nombre_bd+';UID='+
                              nombre_usuario+';PWD=' + password)
    
    cursor = conexion.cursor()
    
    cursor.execute("SELECT TOP (10)* FROM [BD_100].[dbo].[ODBC NUEVA SEMANA FINANCIADA]") 
    row = cursor.fetchone() 
    while row: 
        print(row)
        row = cursor.fetchone()
    # OK! conexión exitosa
except Exception as e:
    # Atrapar error
    print("Ocurrió un error al conectar a SQL Server: ", e)