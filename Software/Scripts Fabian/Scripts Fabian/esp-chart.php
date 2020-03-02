<?php

$servername = "localhost";
$dbname = "tibox_project_temp_humid_gps";
$username = "root";
$password = "";

$conn = new mysqli($servername, $username, $password, $dbname);
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}

$sql = "SELECT ID, ID_NODO, Temperatura_Superficie, Temperatura_Subsuelo, Humedad, Fecha FROM esp32 order by Fecha desc limit 48";

$result = $conn->query($sql);

while ($data = $result->fetch_assoc()){
    $sensor_data[] = $data;
}

$readings_time = array_column($sensor_data, 'Fecha');


$Temperatura_Superficie = json_encode(array_reverse(array_column($sensor_data, 'Temperatura_Superficie')), JSON_NUMERIC_CHECK);
$Temperatura_Subsuelo = json_encode(array_reverse(array_column($sensor_data, 'Temperatura_Subsuelo')), JSON_NUMERIC_CHECK);
$Humedad = json_encode(array_reverse(array_column($sensor_data, 'Humedad')), JSON_NUMERIC_CHECK);
$Fecha = json_encode(array_reverse($readings_time), JSON_NUMERIC_CHECK);

$result->free();
$conn->close();
?>

<!DOCTYPE html>
<html>
<meta name="viewport" content="width=device-width, initial-scale=1">
  <script src="https://code.highcharts.com/highcharts.js"></script>
  <style>
    body {
      min-width: 310px;
      max-width: 1280px;
      height: 500px;
      margin: 0 auto;
    }
    h2 {
      font-family: Arial;
      font-size: 2.5rem;
      text-align: center;
    }

      #map {
        height: 500px;
      }

  </style>
  <body>
    <h2>TIBOX - Proyecto Bazuca</h2>
    <div id="map" class="container"></div>
    <div id="chart-temperatura_superficie" class="container"></div>
    <div id="chart-temperatura_subsuelo" class="container"></div>
    <div id="chart-humedad" class="container"></div>
    
    
<script>
var Temperatura_Superficie = <?php echo $Temperatura_Superficie; ?>;
var Temperatura_Subsuelo = <?php echo $Temperatura_Subsuelo; ?>;
var Humedad = <?php echo $Humedad; ?>;
var Fecha = <?php echo $Fecha; ?>;

var chartT = new Highcharts.Chart({
  chart:{ renderTo : 'chart-temperatura_superficie' },
  title: { text: 'Temperatura Superficie' },
  series: [{
    showInLegend: false,
    data: Temperatura_Superficie
  }],
  plotOptions: {
    line: { animation: false,
      dataLabels: { enabled: true }
    },
    series: { color: '#059e8a' }
  },
  xAxis: { 
    type: 'datetime',
    categories: Fecha
  },
  yAxis: {
    title: { text: 'Temperature (Celsius)' }
  },
  credits: { enabled: false }
});

var chartH = new Highcharts.Chart({
  chart:{ renderTo:'chart-temperatura_subsuelo' },
  title: { text: 'Temperatura Subsuelo' },
  series: [{
    showInLegend: false,
    data: Temperatura_Subsuelo
  }],
  plotOptions: {
    line: { animation: false,
      dataLabels: { enabled: true }
    }
  },
  xAxis: {
    type: 'datetime',
    //dateTimeLabelFormats: { second: '%H:%M:%S' },
    categories: Fecha
  },
  yAxis: {
    title: { text: 'Temperature (Celsius)' }
  },
  credits: { enabled: false }
});


var chartP = new Highcharts.Chart({
  chart:{ renderTo:'chart-humedad' },
  title: { text: 'Humedad' },
  series: [{
    showInLegend: false,
    data: Humedad
  }],
  plotOptions: {
    line: { animation: false,
      dataLabels: { enabled: true }
    },
    series: { color: '#18009c' }
  },
  xAxis: {
    type: 'datetime',
    categories: Fecha
  },
  yAxis: {
    title: { text: 'Humidity (%)' }
  },
  credits: { enabled: false }
});

</script>




<script>
        var i=0;
        var ID=0;
        var ID_NODO=0;
        var Temperatura_Superficie=0;
        var Temperatura_Subsuelo=0;
        var Humedad=0;
        var point=0;
        var Fecha=0;
        function initMap() {
        var map = new google.maps.Map(document.getElementById('map'), {
          center: new google.maps.LatLng(-34.985516, -71.226704),
          zoom: 20,
          mapTypeId: google.maps.MapTypeId.HYBRID
        });
        var infoWindow = new google.maps.InfoWindow;
          downloadUrl('http://localhost/data_marker/phpsqlajax_genxml.php', function(data) {
            var xml = data.responseXML;
            var markers = xml.documentElement.getElementsByTagName('marker');
            Array.prototype.forEach.call(markers, function(markerElem) {
               ID = markerElem.getAttribute('ID');
               ID_NODO = markerElem.getAttribute('ID_NODO');
               Temperatura_Superficie = markerElem.getAttribute('Temperatura_Superficie');
               Temperatura_Subsuelo = markerElem.getAttribute('Temperatura_Subsuelo');
               Humedad = markerElem.getAttribute('Humedad');         
               point = new google.maps.LatLng(
                  parseFloat(markerElem.getAttribute('Latitud')),
                  parseFloat(markerElem.getAttribute('Longitud')));
              Fecha = markerElem.getAttribute('Fecha');
              i++;
            });
            var infowincontent = document.createElement('div');
              var strong = document.createElement('strong');
              strong.textContent = 'Nodo: ' + ID_NODO
              infowincontent.appendChild(strong);
              infowincontent.appendChild(document.createElement('br'));
              var text = document.createElement('text');
              text.textContent = 'Temperatura Superficie: ' + Temperatura_Superficie + '°C'; 
              infowincontent.appendChild(text);
              
              infowincontent.appendChild(document.createElement('br')); //salto de linea
              var text2 = document.createElement('text');
              text2.textContent ='Temperatura_Subsuelo:  ' + Temperatura_Subsuelo + '°C';
              infowincontent.appendChild(text2);

              infowincontent.appendChild(document.createElement('br'));
              var text3 = document.createElement('text');
              text3.textContent ='Humedad: ' + Humedad + '%';
              infowincontent.appendChild(text3);

              infowincontent.appendChild(document.createElement('br'));
              var text4 = document.createElement('text');
              text4.textContent =Fecha;
              infowincontent.appendChild(text4);
            var marker = new google.maps.Marker({
              map: map,
              position: point
            });
            marker.addListener('click', function() {
                infoWindow.setContent(infowincontent);
                infoWindow.open(map, marker);
              })
          });
              
        }

      function downloadUrl(url, callback) {
        var request = window.ActiveXObject ?
            new ActiveXObject('Microsoft.XMLHTTP') :
            new XMLHttpRequest;

        request.onreadystatechange = function() {
          if (request.readyState == 4) {
            request.onreadystatechange = doNothing;
            callback(request, request.status);
          }
        };

        request.open('GET', url, true);
        request.send(null);
      }

      function doNothing() {}
    </script>
    <script async defer
    src="https://maps.googleapis.com/maps/api/js?key=AIzaSyDNHvQrynz5wPnMJ1fYZeuB65tIjqMsytw&callback=initMap">
    </script>




</body>
</html>
