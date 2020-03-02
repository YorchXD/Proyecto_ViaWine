
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
$(document).ready(function () {

    var modelo = @Html.Raw(Newtonsoft.Json.JsonConvert.SerializeObject(Model,Newtonsoft.Json.Formatting.Indented));
    var fecha = (modelo[0]["FechaFabricacion"]).split('T')[0];
    $("#datepicker").datepicker({format: 'yyyy-mm-dd' }).val(fecha);
});

function IniciarProceso() {
    var fecha = $("#datepicker").val();
    var orden = $("#numeroOrden").val();
    var datos = {
        Orden: orden,
        Estado: 1,
        Fecha: fecha
    };

    $.ajax(
            {
                url: '/Proceso/Proceso',
                data: datos,
                dataType: 'json; charset=utf-8',
                type: 'POST',
                success: function (data) {
                alert('Success');
            },
            });

    $('#modal-inicio').modal('hide');
}

function mostrarOrden() {
    var ordenSelect = document.getElementById("numeroOrden");
    var optionSelected = ordenSelect.options[ordenSelect.selectedIndex].value;

    var modelo = @Html.Raw(Newtonsoft.Json.JsonConvert.SerializeObject(Model, Newtonsoft.Json.Formatting.Indented));

    for (var i = 0; i < modelo.length; i++) {
        if (modelo[i]["OrdenFabricacion"] == optionSelected) {
            document.getElementById("SKU").innerHTML = modelo[i]["SKU"];
            document.getElementById("descripcionProducto").innerHTML = modelo[i]["Descripcion"];
            document.getElementById("cantCajasPlan").innerHTML = modelo[i]["CajasPlanificadas"];
            document.getElementById("cantBotellasPlan").innerHTML = modelo[i]["BotellasPlanificadas"];
            document.getElementById("horaInicioPlan").innerHTML = (modelo[i]["HoraInicioPlanificada"]).split('T')[1];
            document.getElementById("horaTerminoPlan").innerHTML = (modelo[i]["HoraTerminoPlanificada"]).split('T')[1];
            document.getElementById("fechaPlan").innerHTML = (modelo[i]["FechaFabricacion"]).split('T')[0];
            document.getElementById("estado").innerHTML = modelo[i]["Estado"];
        }
    }
}