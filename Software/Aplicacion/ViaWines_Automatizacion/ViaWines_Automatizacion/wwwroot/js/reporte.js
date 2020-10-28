var anios = null;
var nombreMeses= [ 'Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio', 'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'];

function filtroReporte() {
    var tipoReporteSelect = document.getElementById("tipoReporte");
    var tipoReporte = tipoReporteSelect.options[tipoReporteSelect.selectedIndex].value;

    var filtroDiario = document.getElementById('filtroDiario');
    var filtroSemanal = document.getElementById('filtroSemanal');
    var filtroMensual = document.getElementById('filtroMensual');
    var filtroAnual = document.getElementById('filtroAnual');

    switch (tipoReporte) {
        case '1':
            filtroDiario.style.display = 'block';
            filtroSemanal.style.display = 'none';
            filtroMensual.style.display = 'none';
            filtroAnual.style.display = 'none';
            break;
        case '2':
            filtroDiario.style.display = 'none';
            filtroSemanal.style.display = 'block';
            filtroMensual.style.display = 'none';
            filtroAnual.style.display = 'none';
            $('#mes1').prop('disabled', 'disabled');
            $('#semana').prop('disabled', 'disabled');
            selectAnios(2);
            break;
        case '3':
            filtroDiario.style.display = 'none';
            filtroSemanal.style.display = 'none';
            filtroMensual.style.display = 'block';
            filtroAnual.style.display = 'none';
            $('#mes2').prop('disabled', 'disabled');
            selectAnios(3);
            break;
        default:
            filtroDiario.style.display = 'none';
            filtroSemanal.style.display = 'none';
            filtroMensual.style.display = 'none';
            filtroAnual.style.display = 'block';
            selectAnios(4);
            break;
    }

}

function ObtenerFechaIncidentes() {
    $.ajax({
        type: 'POST',
        url: '/Reporte/ObtenerFechaIncidentes',
        data: {},
        dataType: 'json',
        async: false,
        success: function (data) {
            // An array of dates
            var eventDates = {};

            for (var i = 0; i < data.length; i++) {
                eventDates[new Date(data[i])] = new Date(data[i]);
            }

            // datepicker
            if ($('#datepicker').val() != "") {
                $('#datepicker').datepicker("destroy");
            }

            $('#datepicker').datepicker({
                destroy: true,
                beforeShowDay: function (date) {
                    var highlight = eventDates[date];
                    if (highlight) {
                        return [true, 'fechaIncidente'];
                    } else {
                        return [false, '', ''];
                    }
                },
                'dateFormat': 'yy-mm-dd',
            }).datepicker("setDate", new Date());
        },
        error: function () {
            $('#title-alert').text("Alerta");
            $('#body-alert').text('Problemas con datepicker en vista incidente.');
            $("#modal-alerta").modal("show");
        }
    });
}


function habilitarSelectMes() {
    var opcion = $('#tipoReporte').val();
    var anio;

    if (opcion == 2) {
        anio = $('#anio1').val();
    }
    else {
        anio = $('#anio2').val();
    }

    $.ajax({
        type: 'POST',
        url: '/Reporte/Filtro',
        data: {
            'Opcion': 2,
            'Anio': anio,
            'Mes': -1
        },
        dataType: 'json',
        async: false,
        success: function (data) {
            if (data.validar) {
                meses = data.fittros;
                if (meses != null || typeof meses != 'undefined') {
                    var opciones = '<option disabled selected value="-1">Seleccione el mes</option>'
                    for (var i = 0; i < meses.length; i++) {
                        opciones += "<option value='" + meses[i]["mes"] + "'>" + nombreMeses[meses[i]["mes"]-1] + "</option>";
                    }
                    switch (opcion) {
                        case "2":
                            $('#mes1').prop('disabled', false);
                            $('#mes1').empty().append(opciones);
                            break;
                        case "3":
                            $('#mes2').prop('disabled', false);
                            $('#mes2').empty().append(opciones);
                            break;
                    }
                }
            }
            else {
                $('#title-alert').text("Alerta");
                $('#body-alert').text('Problemas con obtener los meses del año en vista reporte.');
                $("#modal-alerta").modal("show");
            }

        },
        error: function () {
            $('#title-alert').text("Alerta");
            $('#body-alert').text('Problemas con obtener los meses del año en vista reporte.');
            $("#modal-alerta").modal("show");
        }
    });

}

function habilitarSelectSemana() {
    var anio = $('#anio1').val();
    var mes = $('#mes1').val();

    $.ajax({
        type: 'POST',
        url: '/Reporte/Filtro',
        data: {
            'Opcion': 3,
            'Anio': anio,
            'Mes': mes
        },
        dataType: 'json',
        async: false,
        success: function (data) {
            if (data.validar) {
                var semanas = data.fittros;
                if (semanas != null || typeof semanas != 'undefined') {
                    var opciones = '<option disabled selected value="-1">Seleccione la semana</option>'
                    for (var i = 0; i < semanas.length; i++) {
                        opciones += "<option value='" + semanas[i]["semana"] + "'>" + moment(semanas[i]["iniSemana"]).format('YYYY-MM-DD') + " al " + moment(semanas[i]["finSemana"]).format('YYYY-MM-DD') + "</option>";
                    }
                    $('#semana').prop('disabled', false);
                    $('#semana').empty().append(opciones);
                }
            }
            else {
                $('#title-alert').text("Alerta");
                $('#body-alert').text('Problemas con obtener las semanas del mes en vista reporte.');
                $("#modal-alerta").modal("show");
            }

        },
        error: function () {
            $('#title-alert').text("Alerta");
            $('#body-alert').text('Problemas con obtener las semanas del mes en vista reporte.');
            $("#modal-alerta").modal("show");
        }
    });
}



function reporte() {
    
    var opcion = $('#tipoReporte').val();
    var datos;
    switch (opcion) {
        case "1":
            var fecha = $("#datepicker").datepicker({ dateFormat: 'yy-mm-dd' }).val();
            datos = {
                'Opcion': opcion,
                'Fecha': fecha,
                'Semana': -1,
                'Mes': -1,
                'Anio': -1
            };
            break;
        case "2":
            var anio = $('#anio1').val();
            var mes = $('#mes1').val();
            var semana = $('#semana').val();
            datos = {
                'Opcion': opcion,
                'Fecha': "-",
                'Semana': semana,
                'Mes': mes,
                'Anio': anio
            };
            console.log(datos);
            break;
        case "3":
            var anio = $('#anio2').val();
            var mes = $('#mes2').val();
            datos = {
                'Opcion': opcion,
                'Fecha': "-",
                'Semana': -1,
                'Mes': mes,
                'Anio': anio
            };
            break;
        default:
            var anio = $('#anio3').val();
            datos = {
                'Opcion': opcion,
                'Fecha': "-",
                'Semana': -1,
                'Mes': -1,
                'Anio': anio
            };
            break;
    }

    
    $.ajax({
        type: 'POST',
        url: '/Reporte/Reporte',
        data: datos,
        dataType: 'json',
        async: false,
        success: function (data) {
            if (data.validar) {
                tablaIncidentesArea(data.areas);
                grafico(data.areas);
                indicadoresTiempo_CantInc(data.areas);
            }
            //console.log(data)
        },
        error: function () {
            $('#title-alert').text("Alerta");
            $('#body-alert').text('Problemas con obtener reporte en vista Reporte.');
            $("#modal-alerta").modal("show");
        }
    });
}

function tablaIncidentesArea(respuesta) {
    $('#incidentesArea').DataTable({
        'data': respuesta,
        'responsive': true,
        'dom': "Bfrtip",
        'searching': false,
        'ordering': true,
        'info': false,
        'autoWidth': true,
        'paging': true,
        'scrollX': false,
        'destroy': true,
        'lengthChange': false,
        //"processing": true,
        'iDisplayLength': 9,
        'language': {
            "decimal": "",
            "emptyTable": "No hay información",
            "info": "Mostrando _START_ a _END_ de _TOTAL_ Entradas",
            "infoEmpty": "Mostrando 0 to 0 of 0 Entradas",
            "infoFiltered": "(Filtrado de _MAX_ total entradas)",
            "infoPostFix": "",
            "thousands": ",",
            "lengthMenu": "Mostrar _MENU_ Entradas",
            "loadingRecords": "Cargando...",
            "processing": "Procesando...",
            "search": "Buscar:",
            "zeroRecords": "Sin resultados encontrados",
            "paginate": {
                "first": "Primero",
                "last": "Ultimo",
                "next": "Siguiente",
                "previous": "Anterior"
            }
        },
        'columns': [
            { "data": "name" },
            { "data": "y" },
            { "data": "z" }/*,
            {
                "render": function (data, type, full, meta) {
                    if (full.cantIncidentes != 0) {
                        return '<button class="btn btn-success" onclick="ver(' + full.codigoCorto + ')" title="Ver incidente"><div><i class="glyphicon glyphicon-eye-open"></i></div></button>';
                    }
                    return '';
                }
            }*/
        ]
    });
}

function renameKey(obj, oldKey, newKey) {
    obj[newKey] = obj[oldKey];
    delete obj[oldKey];
}

function grafico(respuesta) {
    respuesta = respuesta.filter(area => area.y > 0);
    Highcharts.chart('container', {
        chart: {
            type: 'variablepie'
        },
        title: {
            text: 'Tiempo del incidentes por área'
        },
        tooltip: {
            headerFormat: '',
            pointFormat: '<span style="color:{point.color}">\u25CF</span> <b> {point.name}</b><br/>' +
                'Cantidad de incientes: <b>{point.z}</b><br/>' +
                'Total tiempo del incidente: <b>{point.y} min.</b><br/>'
        },
        series: [{
            minPointSize: 10,
            innerSize: '20%',
            zMin: 0,
            name: 'data',
            data: respuesta
        }]
    });
}

function selectAnios(opcion) {
    var opciones = '<option disabled selected value="-1">Seleccione el año</option>'
    if (anios != null || typeof anios != 'undefined') {
        for (var i = 0; i < anios.length; i++) {
            opciones += "<option value='" + anios[i]["anio"] + "'>" + anios[i]["anio"]+ "</option>";
        }
        switch (opcion) {
            case 2:
                $('#anio1').empty().append(opciones);
                break;
            case 3:
                $('#anio2').empty().append(opciones);
                break;
            case 4:
                $('#anio3').empty().append(opciones);
                break;
        }
    }
}

function obtenerAnios() {
    $.ajax({
        type: 'POST',
        url: '/Reporte/Filtro',
        data: {
            'Opcion': 1,
            'Anio': -1,
            'Mes': -1
        },
        dataType: 'json',
        async: false,
        success: function (data) {
            if (data.validar) {
                console.log(data.fittros);
                anios = data.fittros;
            }
            else {
                $('#title-alert').text("Alerta");
                $('#body-alert').text('Problemas con obtener los años en vista Reporte.');
                $("#modal-alerta").modal("show");
            }

        },
        error: function () {
            $('#title-alert').text("Alerta");
            $('#body-alert').text('Problemas con obtener los años en vista Reporte.');
            $("#modal-alerta").modal("show");
        }
    });
}

function indicadoresTiempo_CantInc(areas)
{
    var cantIncidentes = 0;
    var cantTiempo = 0;
    for (var i = 0; i < areas.length; i++)
    {
        cantIncidentes += areas[i].z;
        cantTiempo += areas[i].y;
    }
    document.getElementById("Total").innerHTML = cantIncidentes;
    document.getElementById("TiempoTotal").innerHTML = cantTiempo + " mín.";
    var promedio = cantTiempo / cantIncidentes;

    if (!isNaN(promedio)) {
        document.getElementById("TiempoPromedio").innerHTML = promedio.toFixed(2) + " mín.";
    }
    else {
        document.getElementById("TiempoPromedio").innerHTML = 0.00 + " mín.";
    }
    
    

    var opcion = $('#tipoReporte').val();
    var datos;
    switch (opcion) {
        case "1":
            var fecha = $("#datepicker").datepicker({ dateFormat: 'yy-mm-dd' }).val();
            datos = {
                'Opcion': opcion,
                'Dia': fecha,
                'Semana': -1,
                'Mes': -1,
                'Anio': -1
            };
            break;
        case "2":
            var anio = $('#anio1').val();
            var mes = $('#mes1').val();
            var semana = $('#semana').val();
            datos = {
                'Opcion': opcion,
                'Dia': "-",
                'Semana': semana,
                'Mes': mes,
                'Anio': anio
            };
            console.log(datos);
            break;
        case "3":
            var anio = $('#anio2').val();
            var mes = $('#mes2').val();
            datos = {
                'Opcion': opcion,
                'Dia': "-",
                'Semana': -1,
                'Mes': mes,
                'Anio': anio
            };
            break;
        default:
            var anio = $('#anio3').val();
            datos = {
                'Opcion': opcion,
                'Dia': "-",
                'Semana': -1,
                'Mes': -1,
                'Anio': anio
            };
            break;
    }

    $.ajax({
        type: 'POST',
        url: '/Reporte/Indicadores',
        data: datos,
        dataType: 'json',
        async: false,
        success: function (data) {
            if (data.validar) {
                document.getElementById("OrdenPlan").innerHTML = data.cantOrdenesPlan;
                document.getElementById("OrdenNoIni").innerHTML = data.cantOrdenesNoIni;
                document.getElementById("OrdenPausadas").innerHTML = data.cantOrdenesPausadas;
                document.getElementById("OrdenPospuestas").innerHTML = data.cantOrdenesPospuestas;
                document.getElementById("OrdenFinalizadas").innerHTML = data.cantOrdenesFinalizadas;
            }
            //console.log(data)
        },
        error: function () {
            $('#title-alert').text("Alerta");
            $('#body-alert').text('Problemas con obtener reporte en vista Reporte.');
            $("#modal-alerta").modal("show");
        }
    });
}
