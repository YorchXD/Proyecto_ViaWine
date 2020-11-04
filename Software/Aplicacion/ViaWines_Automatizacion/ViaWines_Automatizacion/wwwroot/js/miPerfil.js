var roles = null;
var idUsuarioAux = "";
var datosPerfil = null;

function obtenerRoles() {
    $.ajax({
        type: 'POST',
        url: '/Usuario/LeerRoles',
        data: "",
        dataType: 'json',
        async: false,
        success: function (data) {
            if (data.validar) {
                roles = data.roles;
                var cantRoles = data.roles.length;
                $('#rolUsuario').empty().append('<option disabled selected value="-1">Seleccione el rol del usuario</option>');
                for (var i = 0; i < cantRoles; i++) {
                    $('#rolUsuario').append("<option  value='" + data.roles[i]["id"] + "'>" + data.roles[i]["nombre"] + "</option>");
                }
            }
        },
        error: function () {
            $('#title-alert').text("Alerta");
            $('#body-alert').text('Problemas con obtener los roles en la vista Administración de usuarios.');
            $("#modal-alerta").modal("show");
        }
    });
}

function obtenerMiPerfil() {
    $.ajax({
        type: 'POST',
        url: '/Usuario/VerMiPerfil',
        data: "",
        dataType: 'json',
        async: false,
        success: function (data) {
            datosPerfil = data.usuario;
            idUsuarioAux = datosPerfil.id;
            $('#email-miPerfil').val(datosPerfil.email);
            $('#nombre-miPerfil').val(datosPerfil.nombre);
            $('#cargo-miPerfil').val(datosPerfil.cargo);

            var cantRoles = roles.length;
            for (var i = 0; i < cantRoles; i++) {
                if (roles[i]["id"] == datosPerfil.idRol) {
                    $('#rolUsuario-miPerfil').val(roles[i]["nombre"]);
                    break;
                }
            }
        },
        error: function () {
            $('#title-alert').text("Alerta");
            $('#body-alert').text('Problemas con obtener los roles en la vista Mi perfil.');
            $("#modal-alerta").modal("show");
        }
    });
}

function obtenerMiPerfilEdicion() {
    console.log(datosPerfil);
    idUsuarioAux = datosPerfil.id;
    $('#email-editar').val(datosPerfil.email);
    $('#nombre-editar').val(datosPerfil.nombre);
    $('#cargo-editar').val(datosPerfil.cargo);

    var cantRoles = roles.length;
    for (var i = 0; i < cantRoles; i++) {
        if (roles[i]["id"] == datosPerfil.idRol) {
            $('#rolUsuario-editar').val(roles[i]["nombre"]);
            break;
        }
    }
}

function guardarDatosPerfil() {
    var nombre = $("#nombre-editar").val();
    var cargo = $("#cargo-editar").val();
    if (nombre != "" && cargo != "") {
        var datos = {
            'IdUsuario': idUsuarioAux,
            'Nombre': nombre,
            'Cargo': cargo
        }

        $.ajax({
            type: 'POST',
            url: '/Usuario/EditarMiPerfil',
            data: datos,
            dataType: 'json',
            async: false,
            success: function (data) {
                if (data.validar) {
                    $("#modal-editar-perfil").modal("hide");
                    $("#modal-confirm-editar-perfil-final").modal("show");
                }
            },
            error: function () {
                $('#title-alert').text("Alerta");
                $('#body-alert').text('Problemas con guardar los cambios del perfil de usuario en la vista Administración de usuarios.');
                $("#modal-alerta").modal("show");
            }
        });
    }
    else {
        $('#title-alert').text("Alerta");
        $('#body-alert').text('No se puede guardar los datos debido a que existen campos vacios. Favor de verificarlos y vuelva a intentarlo');
        $("#modal-alerta").modal("show");
    }
}

/*Editar perfil*/
$('#btnModalModificarPerfil').click(function () {
    //resetear();
    obtenerMiPerfilEdicion();
    $('#modal-editar-perfil').modal('show');
});

$('#btnModificarPerfil').click(function () {
    $('#title-confirm-editar-perfil').text("Editar mi perfil");
    $('#body-confirm-editar-perfil').text("¿Está seguro que desea guardar los cambios del perfil?");
    $("#modal-confirmar-editar-perfil").modal("show");
});

$('#btnConfirmarEditarUsuario').click(function () {
    $("#modal-confirmar-editar-perfil").modal("hide");
    guardarDatosPerfil();
});

$('#btnConfirmacion').click(function () {
    location.reload();
});

/*Modificar clave*/
$('#btnModificarClave').click(function () {
    $('#modal-cambiar-clave').modal('show');
});

$('#btnCambiarClave').click(function () {
    $('#title-confirm-cambiar-clave').text("Editar mi perfil");
    $('#body-confirm-cambiar-clave').text("¿Está seguro que desea cambiar la clave?");
    $("#modal-confirmar-cambiar-clave").modal("show");
});


$('#btnConfirmarCambiarClave').click(function () {
    $("#modal-confirmar-cambiar-clave").modal("hide");
    var claveTemporal = $('#claveActual').val();
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
                $("#modal-cambiar-clave").modal("hide");
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

function mostrarClaveActual() {
    var cambio = document.getElementById("claveActual");
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