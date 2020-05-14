function Actualizar_Estado(estado) {
    var orden = $("#numeroOrden").val();
    var datos = {
        'OrdenFabricacion': orden,
        'Estado': estado
    };
    $.ajax(
        {
            url: '/Proceso/ActualizarEstadoProceso',
            data: datos,
            //contentType: "application/json; charset=utf-8",
            datatype: "json",
            type: 'POST',
            success: function (data) {
                switch (estado) {
                    case 1:
                        $('#modal-inicio').modal('hide');
                        alert('El proceso se ha iniciado correctamente');
                        break;
                    case 2:
                        $("#modal-pausar").modal('hide');
                        alert('El proceso se ha pausado correctamente');
                        break;
                    case 3:
                        $("#modal-posponer").modal('hide');
                        alert('El proceso se ha pospueto correctamente');
                        break;
                    default:
                        $("#modal-finalizar").modal('hide');
                        alert('El proceso se ha finalizado correctamente');
                        break;
                }
                location.reload();
            },
            error: function () {
                alert('El proceso no se ha iniciado correctamente. Intentelo mas tarde.')
            }
        });
}

function exist_proces_ini(tipoAccion) {
    var orden = $("#numeroOrden").val();
    var datos = {
        'OrdenFabricacion': orden,
        'OpcionAccion': tipoAccion
    };
    $.ajax(
    {
        url: '/Proceso/Exit_proces_ini',
        data: datos,
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        type: 'GET',
        success: function (data)
        {
            if (data.existeProceso)
            {
                switch (tipoAccion)
                {
                    case 1:
                        $('#title-ini-process').text(data.titulo);
                        $('#body-ini-process').text(data.contenido);
                        $("#modal-inicio").modal("show");
                        break;
                    case 2:
                        $('#title-pause-process').text(data.titulo);
                        $('#body-pause-process').text(data.contenido);
                        $("#modal-pausar").modal("show");
                        break;
                    case 3:
                        $('#title-postpone-process').text(data.titulo);
                        $('#body-postpone-process').text(data.contenido);
                        $("#modal-posponer").modal("show");
                        break;
                    default:
                        $('#title-finalize-process').text(data.titulo);
                        $('#body-finalize-process').text(data.contenido);
                        $("#modal-finalizar").modal("show");
                        break;
                }
            }
            else
            {
                $('#title-alert').text(data.titulo);
                $('#body-alert').text(data.contenido);
                $("#modal-alerta").modal("show");
            }
        },
        error: function ()
        {
            alert("Error inesperado, vuelva a intentarlo mas tarde o contactese con Tibox para informar en detalle cuando ocurrió el error.");
        },
    });
}

function mostrarOrden(modelo) {
    var ordenSelect = document.getElementById("numeroOrden");
    var optionSelected = ordenSelect.options[ordenSelect.selectedIndex].value;
    

    for (var i = 0; i < modelo.length; i++) {
        if (modelo[i]["OrdenFabricacion"] == optionSelected) {
            document.getElementById("SKU").innerHTML = modelo[i]["SKU"];
            document.getElementById("descripcionProducto").innerHTML = modelo[i]["Descripcion"];
            document.getElementById("cantCajasPlan").innerHTML = modelo[i]["CajasPlanificadas"];
            document.getElementById("cantBotellasPlan").innerHTML = modelo[i]["BotellasPlanificadas"];
            document.getElementById("horaInicioPlan").innerHTML = modelo[i]["HoraInicioPlanificada"];
            document.getElementById("horaTerminoPlan").innerHTML = modelo[i]["HoraTerminoPlanificada"];
            document.getElementById("fechaPlan").innerHTML = (modelo[i]["FechaFabricacion"]).split('T')[0];
            switch (modelo[i]["Estado"]) {
                case 0:
                    document.getElementById("estado").innerHTML = 'No iniciada';
                    break;
                case 1:
                    document.getElementById("estado").innerHTML = 'Iniciada';
                    break;
                case 2:
                    document.getElementById("estado").innerHTML = 'Pausada';
                    break;
                case 3:
                    document.getElementById("estado").innerHTML = 'Pospuesta';
                    break;
                default:
                    document.getElementById("estado").innerHTML = 'Finalizada';
            }

        }
    }
}

