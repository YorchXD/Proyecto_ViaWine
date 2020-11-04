function mostrarClaveActual() {
    var cambio = document.getElementById("claveTemporal");
    if (cambio.type == "password") {
        cambio.type = "text";
        $('#iconoClaveActual').removeClass('fa fa-eye-slash').addClass('fa fa-eye');
    } else {
        cambio.type = "password";
        $('#iconoClaveActual').removeClass('fa fa-eye').addClass('fa fa-eye-slash');
    }
}

function mostrarNuevaClave() {
    var cambio = document.getElementById("nuevaClave");
    if (cambio.type == "password") {
        cambio.type = "text";
        $('#iconoNuevaClave').removeClass('fa fa-eye-slash').addClass('fa fa-eye');
    } else {
        cambio.type = "password";
        $('#iconoNuevaClave').removeClass('fa fa-eye').addClass('fa fa-eye-slash');
    }
}

function mostrarNuevaClaveConfirmada() {
    var cambio = document.getElementById("nuevaClaveConfirmada");
    if (cambio.type == "password") {
        cambio.type = "text";
        $('#iconoNuevaClaveConfirmada').removeClass('fa fa-eye-slash').addClass('fa fa-eye');
    } else {
        cambio.type = "password";
        $('#iconoNuevaClaveConfirmada').removeClass('fa fa-eye').addClass('fa fa-eye-slash');
    }
}

$('#btnConfirmarCambiarClave').click(function () {
    $("#modal-confirmar-cambiar-clave").modal("hide");
    var claveTemporal = $('#claveTemporal').val();
    var nuevaClave = $('#nuevaClave').val();
    var nuevaClaveConfirmada = $('#nuevaClaveConfirmada').val();


    if (claveTemporal != "" && nuevaClave != "" && nuevaClaveConfirmada != "") {
        if (claveTemporal.indexOf(" ") === -1 && nuevaClave.indexOf(" ") === -1 && nuevaClaveConfirmada.indexOf(" ") === -1) {
            if (nuevaClave == nuevaClaveConfirmada) {
                if (nuevaClave != claveTemporal) {
                    actualizarClave(claveTemporal, nuevaClave, nuevaClaveConfirmada);
                }
                else {
                    $('#title-alert').text("Alerta");
                    $('#body-alert').text('La nueva clave no debe ser igual que la temporal. Favor de corregirlas e intente nuevamente.');
                    $("#modal-alerta").modal("show");
                }
            }
            else {
                $('#title-alert').text("Alerta");
                $('#body-alert').text('Las claves no coiciden. Favor de corregirlas e intente nuevamente.');
                $("#modal-alerta").modal("show");
            }
        }
        else {
            $('#title-alert').text("Alerta");
            $('#body-alert').text('Las claves no deben tener espacios. Favor de corregirlas e intente nuevamente.');
            $("#modal-alerta").modal("show");
        }
    }
    else {
        $('#title-alert').text("Alerta");
        $('#body-alert').text('Verifique que no existan campos sin completar e intentelo nuevamente.');
        $("#modal-alerta").modal("show");
    }
});

$('#btnCambiarClave').click(function () {

    $('#title-confirm-cambiar-clave').text("Cambiar clave");
    $('#body-confirm-cambiar-clave').text("¿Está seguro que desea guardar esta nueva clave?");
    $("#modal-confirmar-cambiar-clave").modal("show");
});

function actualizarClave(claveTemporal, nuevaClave, nuevaClaveConfirmada) {
    var datos = {
        'ClaveTemporal': claveTemporal,
        'NuevaClave': nuevaClave,
        'NuevaClaveConfirmada': nuevaClaveConfirmada
    }
    $.ajax({
        type: 'POST',
        url: '/Usuario/ActualizarClave',
        data: datos,
        dataType: 'json',
        async: false,
        success: function (data) {
            if (data.validar) {
                $('#title-clave-cambiada').text("Registro exitoso");
                $('#body-clave-cambiada').text(data.mensaje);
                $("#modal-clave-cambiada").modal("show");
            }
            else {
                $('#title-alert').text("Alerta");
                $('#body-alert').text(data.mensaje);
                $("#modal-alerta").modal("show");
            }
        },
        error: function () {
            $('#title-alert').text("Alerta");
            $('#body-alert').text('Problemas para cambiar la clave temporal en la vista Clave temporal.');
            $("#modal-alerta").modal("show");
        }
    });
}