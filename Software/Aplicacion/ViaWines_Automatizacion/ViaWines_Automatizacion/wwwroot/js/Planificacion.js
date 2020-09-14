var ordenesModalAgregar = null;

function buscarPlanificacion() {
    var fecha = $("#datepicker").datepicker({ dateFormat: 'yy-mm-dd' }).val();
    var tipo = $('#tipoOrden').val();
    mostrarTablaOrdenes(fecha, tipo);
}

function mostrarTablaOrdenes(fecha, opcion) {
    var datos = {
        'fecha': fecha,
        'opcion': opcion
    };
    $('#tabla').DataTable({
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
        'iDisplayLength': 5,
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

        'ajax': {
            "url": "/Planificacion/LeerPlanificaciones",
            "method": "POST",
            "data": datos,
            "dataSrc": function (data) {
                //Make your callback here.

                if (data.validacion == false) {
                    $('#title-alert').text("Alerta");
                    $('#body-alert').text("Puede que aún no existan ordenes cargadas para fecha " + fecha + " en el sistema o existe algun problema con un campo de una orden. Verifique los campos en SAP como por ejemplo el Formato o la Unidad (caja o botella) e intentelo nuevamente. Si el problema persiste contáctese con TIBOX");
                    $("#modal-alerta").modal("show");
                }
                //console.log(data)
                
                return data.ordenes;
            } ,
        },        
        'columns': [
            { "data": "secuencia" },
            { "data": "ordenFabricacion" },
            { "data": "version" },
            { "data": "cliente" },
            { "data": "sku" },
            { "data": "descripcion" },
            { "data": "botellasPlanificadas" },
            { "data": "botellasFabricadas" },
            { "data": "cajasPlanificadas" },
            { "data": "cajasFabricadas" },
            {
                "data": "fechaFabricacion", render: function (d, type, full, meta) {
                    var fecha = moment(new Date(d)).format('YYYY-MM-DD');
                    return fecha;
                }
            },
            {
                "data": "fechaHoraInicio", render: function (d, type, full, meta) {
                    var fecha = moment(new Date(d)).format('YYYY-MM-DD HH:mm:ss');
                    if (fecha == "2020-01-01 00:00:00")
                        return "";
                    return fecha;
                }
            },
            {
                "data": "fechaHoraTermino", render: function (d, type, full, meta) {
                    var fecha = moment(new Date(d)).format('YYYY-MM-DD HH:mm:ss');
                    if (fecha == "2020-01-01 00:00:00")
                        return "";
                    return fecha;
            } },
            {
                "data": "estado", "render": function (estado, type, full, meta) {
                    var estadoAux = "";
                    switch (estado) {
                        case 1:
                            estadoAux = "<span class='label bg-start'>Iniciada</span>"
                            break;
                        case 2:
                            estadoAux = "<span class='label bg-pause'>Pausada</span>"
                            break;
                        case 3:
                            estadoAux = "<span class='label bg-postpone'>Pospuesta</span>"
                            break;
                        case 4:
                            estadoAux = "<span class='label bg-end'>Finalizada</span>";
                            break;
                        default:
                            estadoAux = "<span class='label bg-gray'>No iniciada</span>";
                    }
                    return estadoAux;
                }
            },
            {
                "render": function (data, type, full, meta) {
                    var porcentaje = "";
                    switch (full.estado) {
                        case 1:
                            porcentaje = "<span class='label bg-start'>" + full.porcentajeAvance + "%</span>";
                            break;
                        case 2:
                            porcentaje = "<span class='label bg-pause'>" + full.porcentajeAvance + "%</span>";
                            break;
                        case 3:
                            porcentaje = "<span class='label bg-postpone'>" + full.porcentajeAvance + "%</span>"
                            break;
                        case 4:
                            porcentaje = "<span class='label bg-end'>" + full.porcentajeAvance + "%</span>";
                            break;
                        default:
                            porcentaje = "<span class='label bg-gray'>" + full.porcentajeAvance + "%</span>";
                    }
                    return porcentaje;
                }
            },
        ]
    });
    
}

function fechaActual() {
    var hoy = new Date();
    var dd = hoy.getDate();
    var MM = hoy.getMonth() + 1;
    var yyyy = hoy.getFullYear();
    if (dd < 10) {
        dd = '0' + dd;
    }

    if (MM < 10) {
        MM = '0' + MM;
    }

    hoy = yyyy + '-' + MM + '-' + dd;
    return hoy;
}

function agregarOrdenesNuevas() {
    $('#modal-agregar-ordenes').modal('hide');

    var modal = document.getElementById('myModal');
    modal.style.display = "block";
    var ordenFabricacion = $('#numeroOrden').val();
    var fecha = $('#datepickerAgregar').val();
    var datos = {
        'OrdenFabricacion': ordenFabricacion,
        'Fecha': fecha
    };

    $.ajax({
        url: "/Planificacion/AgregarOrdenesNuevas",
        method: "POST",
        data: datos,
        success: function (data)
        {
            if (data == true)
            {
                modal.style.display = "none";
                $('#title-confirm').text("Nuevas ordenes");
                $('#body-confirm').text("Se ha ingresado correctamente la orden N°" + ordenFabricacion + " en la fecha " + fecha);
                $("#modal-confirm").modal("show");
            }
            else
            {
                modal.style.display = "none";
                $('#title-alert').text("Alerta");
                $('#body-alert').text("No se pudo ingresar la orden N°" + ordenFabricacion + " en la fecha " + fecha + ". Verificar si la orden ya se encuentra en el sistema. En caso de que la orden no existiera es porque ocurrió un problema en la función AgregarNuevasOrdenes en la vista Planificación, por ende, favor de informar el problema a TIBOX.");
                $("#modal-alerta").modal("show");
            }
        }
    })
}

function cambiarTipo() {
    modal = document.getElementById('myModal');
    modal.style.display = "block";
    var opcion = $('#tipoOrden').val();
    switch (opcion) {
        case '1':
            var fecha = fechaActual();
            fechasOrdenes(opcion, 'ordenesDia', fecha);
            break;
        case '2':
            fechasOrdenes(opcion, 'ordenesFuturas', "");
            break;

        default:/*opcion==3*/
            var fecha = fechaActual();
            fechasOrdenes(opcion, 'ordenesDia', fecha);
            break;
    }
    fecha = $("#datepicker").datepicker({ dateFormat: 'yy-mm-dd' }).val();
    mostrarTablaOrdenes(fecha, opcion);
    modal.style.display = "none";
}

function fechasOrdenes(opcion, estilo, fecha) {
    var fechaAux = "";
    $.ajax({
        type: 'POST',
        url: '/Planificacion/GetFechasTipo',
        data: {'opcion': opcion},
        dataType: 'json',
        async: false,
        success: function (data) {
            // An array of dates
            var eventDates = {};
            if (fecha != "") {
                var parts = fecha.split('-');
                fechaAux = new Date(parts[0], parts[1] - 1, parts[2]);

            }
            else {
                fechaAux = new Date(data[0]);
            }

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
                        return [true, estilo];
                    } else {
                        return [false, '', ''];
                    }
                },
                'dateFormat': 'yy-mm-dd',
            }).datepicker("setDate", fechaAux);
        },
        error: function () {
            $('#title-alert').text("Alerta");
            $('#body-alert').text("Problemas con datepicker en la función fechasOrdenes de la vista Planificacion.");
            $("#modal-alerta").modal("show");
            //alert('Problemas con datepicker en vista Planificacion.');
        }
    });
}

function fechasOrdenesAgregar() {
    modal = document.getElementById('myModal');
    modal.style.display = "block";
    var fechaAux = "";
    $.ajax({
        type: 'POST',
        url: '/Planificacion/GetFechasTipo',
        data: { 'opcion': 2 },
        dataType: 'json',
        async: false,
        success: function (data) {
            // An array of dates
            var eventDates = {};
            fechaAux = new Date(data[0]);

            for (var i = 0; i < data.length; i++) {
                eventDates[new Date(data[i])] = new Date(data[i]);
            }

            // datepicker
            if ($('#datepickerAgregar').val() != "") {
                $('#datepickerAgregar').datepicker("destroy");
            }

            $('#datepickerAgregar').datepicker({
                destroy: true,
                beforeShowDay: function (date) {
                    var highlight = eventDates[date];
                    if (highlight) {
                        return [true, 'ordenesFuturas'];
                    } else {
                        return [false, '', ''];
                    }
                },
                'dateFormat': 'yy-mm-dd',
            }).datepicker("setDate", fechaAux);
            modal.style.display = "none";
        },
        error: function () {
            ordenesModalAgregar = null;
            modal.style.display = "none";
            $('#title-alert').text("Alerta");
            $('#body-alert').text("Problemas con datepicker en la función fechasOrdenesAgregar de la vista Planificacion.");
            $("#modal-alerta").modal("show");
        }
    });
}


function obtenerOrdenes() {
    modal = document.getElementById('myModal');
    modal.style.display = "block";
    var fecha = $("#datepickerAgregar").datepicker({ dateFormat: 'yy-mm-dd' }).val();
    var opcion = 2;
    $.ajax({
        type: 'POST',
        url: '/Planificacion/LeerPlanificaciones',
        data: {
            'opcion': 2,
            'fecha': fecha
        },
        dataType: 'json',
        //async: false,
        success: function (data) {
            if (data.validacion == true) {
                ordenesModalAgregar = data.ordenes;
                iniciarOrdenesSelect();
                modal.style.display = "none";
            }
            else {
                modal.style.display = "none";
                $('#title-alert').text("Alerta");
                $('#body-alert').text("Problemas en la funcion obtenerOrdenes en vista Planificacion al agregar una nueva orden.");
                $("#modal-alerta").modal("show");
            }
        },
        error: function () {
            ordenesModalAgregar = null;
            modal.style.display = "none";
            $('#title-alert').text("Alerta");
            $('#body-alert').text('Problemas en la funcion obtenerOrdenes en vista Planificacion.');
            $("#modal-alerta").modal("show");
        }
    });
}

function iniciarOrdenesSelect() {
    $('#numeroOrden').empty();
    $('#numeroOrden').append('<option disabled selected value="-1">Seleccione una orden</option>');

    for (var i = 0; ordenesModalAgregar != null && i < ordenesModalAgregar.length; i++) {
        $('#numeroOrden').append("<option  value='" + ordenesModalAgregar[i]["ordenFabricacion"] + "'>" + ordenesModalAgregar[i]["ordenFabricacion"] + "</option>");
    }
}

function mostrarOrden() {
    var ordenSelect = document.getElementById("numeroOrden");
    var numeroOrden = ordenSelect.options[ordenSelect.selectedIndex].value;
    if (ordenesModalAgregar != null) {
        var orden = ordenesModalAgregar.filter(orden => orden.ordenFabricacion == numeroOrden);
        Orden(orden[0]);
    }
}

function Orden(modelo)
{
    document.getElementById("SKU").innerHTML = modelo["sku"];
    document.getElementById("descripcionProducto").innerHTML = modelo["descripcion"];
    document.getElementById("cantCajasPlan").innerHTML = modelo["cajasPlanificadas"];
    document.getElementById("cantBotellasPlan").innerHTML = modelo["botellasPlanificadas"];
    document.getElementById("fechaPlan").innerHTML = (modelo["fechaFabricacion"]).split('T')[0];
}


function resetear() {
    $('#numeroOrden').empty();
    $('#numeroOrden').append('<option disabled selected value="-1">Seleccione una orden</option>');

    document.getElementById("SKU").innerHTML = "-";
    document.getElementById("descripcionProducto").innerHTML = "-";
    document.getElementById("cantCajasPlan").innerHTML = "-";
    document.getElementById("cantBotellasPlan").innerHTML = "-";
    document.getElementById("fechaPlan").innerHTML = "-";
    document.getElementById("datepickerAgregar").innerHTML = "";
}



function actualizarTablaPlanificacion() {
    var opcion = $('#tipoOrden').val();
    fecha = $("#datepicker").datepicker({ dateFormat: 'yy-mm-dd' }).val();
    mostrarTablaOrdenes(fecha, opcion);
}
setInterval(actualizarTablaPlanificacion, 60000*5);