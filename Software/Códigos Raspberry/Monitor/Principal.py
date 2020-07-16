
import threading
from Proceso import Proceso
from time import sleep
  
# Cuantos threads queremos ejecutar  
THREADS_COUNT = 3  

print('Starting %d threads...' % THREADS_COUNT)
for i in range(THREADS_COUNT):
    td = Proceso()
    td.start()
    sleep(60)


