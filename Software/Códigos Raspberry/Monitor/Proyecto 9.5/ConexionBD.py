#!/usr/bin/env python2
# -*- coding: utf-8 -*-
"""
Created on Fri Jun 26 17:20:30 2020

@author: pi
"""

import pyodbc

class ConexionBD:
    def __init__(self):
        self.conn = None

    def __enter__(self):
        self.conn = pyodbc.connect('Driver={freetds};SERVER=190.171.160.83;PORT=1433;DATABASE=Automatizacion_ViaWines3.0;UID=sa;PWD=J1h4m3b012*;TDS_Version=4.2;')
        self.conn.autocommit = True

    def __exit__(self, *args):
        if self.conn:
            self.conn.close()
            self.conn = None