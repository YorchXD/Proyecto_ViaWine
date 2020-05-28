import datetime as dt
now = dt.datetime.now()
delta = dt.timedelta(seconds = 60)
t = now.time()
print(t)
# 12:39:11.039864

print((dt.datetime.combine(dt.date(1,1,1),t) + delta).time())
# 00:39:11.039864