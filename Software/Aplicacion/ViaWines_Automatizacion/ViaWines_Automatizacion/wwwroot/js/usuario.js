var idUsuarioAux = "";
var usuarios = null;
var roles = null;

function obtenerUsuarios(actualizarUsuarios,eliminarUsuarios) {
    $.ajax({
        type: 'POST',
        url: '/Usuario/LeerUsuarios',
        data: "",
        dataType: 'json',
        async: false,
        success: function (data)
        {
            if (data.validar) {
                usuarios = data.usuarios;
                if (actualizarUsuarios == 1 || eliminarUsuario == 1)
                {
                    if (actualizarUsuarios == 1 && eliminarUsuario == 1)
                    {
                        tablaUsuario(data.usuarios, true, true, true);
                    }
                    else if (actualizarUsuarios == 1 && eliminarUsuario != 1)
                    {
                        tablaUsuario(data.usuarios, true, true, false);
                    }
                    else
                    {
                        tablaUsuario(data.usuarios, true, false, true);
                    }
                }
                else
                {
                    tablaUsuario(data.usuarios, false, false, false);
                }
            }
        },
        error: function () {
            $('#title-alert').text("Alerta");
            $('#body-alert').text('Problemas con obtener los usuarios en la vista Administración de usuarios.');
            $("#modal-alerta").modal("show");
        }
    });
}

function tablaUsuario(respuesta, acciones, actualizarUsuarios, eliminarUsuarios) {
    $('#tablaUsuarios').DataTable({
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
        "columnDefs": [
            {
                "targets": [5],
                "visible": acciones
            }
        ],
        'columns': [
            { "data": "id" },
            { "data": "nombre" },
            { "data": "email" },
            { "data": "cargo" },
            { "data": "nombreRol" },
            {
                "render": function (data, type, full, meta) {
                    var acciones = "";
                    if (actualizarUsuarios)
                    {
                        acciones = '<button class="btn bg-orange" onclick="editarUsuario(' + full.id + ')" title="Editar usuario"><div><i class="glyphicon glyphicon-pencil"></i></div></button>';
                        acciones += '<button class="btn btn-success" onclick="preguntarResetearClave(' + full.id + ')" title="Resetear clave"><div><i class="fa fa-key"></i></div></button>';
                    }
                    if (eliminarUsuarios)
                    {
                        acciones += '<button class="btn btn-danger" onclick="preguntarEliminar(' + full.id + ')" title="Eliminar Usuario"><div><i class="glyphicon glyphicon-trash"></i></div></button>';
                    }
                    return acciones;
                }
            }
        ]
    });
}

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

function agregarUsuario()
{
    var email = $('#email').val();
    var nombre = $('#nombre').val();
    var cargo = $('#cargo').val();

    var rolSelect = document.getElementById("rolUsuario");
    var rolUsuario = rolSelect.options[rolSelect.selectedIndex].value;

    //var rolUsuario = $('#rolUsuario').val();
    console.log(rolUsuario);
    if (nombre != "" && cargo != "" && email != "") {
        if (rolUsuario != -1) {
            if (validar_email(email)) {
                var datos = {
                    'Email': email,
                    'Nombre': nombre,
                    'Cargo': cargo,
                    'RefRol': rolUsuario
                };

                $.ajax({
                    type: 'POST',
                    url: '/Usuario/AgregarUsuario',
                    data: datos,
                    dataType: 'json',
                    async: false,
                    success: function (data) {
                        if (data.validar) {
                            $("#modal-agregar-usuario").modal("hide");
                            $('#title-confirm').text("Registro exitoso");
                            $('#body-confirm').text('El usuario ha sido registrado correctamente.');
                            $("#modal-confirm").modal("show");
                            obtenerUsuarios();
                        }
                        else {
                            $('#title-alert').text("Alerta");
                            $('#body-alert').text('El no se ha podido registrar correctamente. Intentelo nuevamente y si el problema persiste favor de contactarse con Tibox');
                            $("#modal-alerta").modal("show");
                        }
                    },
                    error: function () {
                        $('#title-alert').text("Alerta");
                        $('#body-alert').text('Problemas con obtener los roles en la vista Administración de usuarios.');
                        $("#modal-alerta").modal("show");
                    }
                });
            }
            else {
                $('#title-alert').text("Alerta");
                $('#body-alert').text('El email no es válido.');
                $("#modal-alerta").modal("show");
            }
        }
        else {
            $('#title-alert').text("Alerta");
            $('#body-alert').text('Debe seleccionar un rol para el usuario.');
            $("#modal-alerta").modal("show");
        }
    }
    else {
        $('#title-alert').text("Alerta");
        $('#body-alert').text('Existen campos vacios. Favor de verificarlos e intentarlo nuevamente.');
        $("#modal-alerta").modal("show");
    }
}

function validar_email(email) {
    var regex = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    return regex.test(email) ? true : false;
}


function resetearClave() {
    $.ajax({
        type: 'POST',
        url: '/Usuario/ResetearClave',
        data: {'IdUsuario':idUsuarioAux},
        dataType: 'json',
        async: false,
        success: function (data) {
            if (data.validar) {
                $("#modal-agregar-usuario").modal("hide");
                $("#modal-confirm-reseteo-clave").modal("show");
                idUsuarioAux = "";
                obtenerUsuarios();
            }
            else {
                $('#title-alert').text("Alerta");
                $('#body-alert').text('Problemas para resetear la clave del usuario seleccionado en la vista Administración de usuarios.');
                $("#modal-alerta").modal("show");
            }
        },
        error: function () {
            $('#title-alert').text("Alerta");
            $('#body-alert').text('Problemas para resetear la clave del usuario seleccionado en la vista Administración de usuarios.');
            $("#modal-alerta").modal("show");
        }
    });
}

function preguntarEliminar(idUsuario) {
    idUsuarioAux = idUsuario;
    $('#title-confirm-eliminar-usuario').text("Eliminación de usuario");
    $('#body-confirm-eliminar-usuario').text('¿Está seguro que desea eliminar al usuario seleccionado?');
    $("#modal-confirmar-eliminar-usuario").modal("show");
}

function preguntarResetearClave(idUsuario) {
    idUsuarioAux = idUsuario;
    $('#title-confirm-resetear-clave').text("Resetear clave");
    $('#body-confirm-resetear-clave').text('¿Está seguro que desea resetear la clave del usuario seleccionado?');
    $("#modal-confirmar-resetear-clave").modal("show");
}

function eliminarUsuario() {
    $.ajax({
        type: 'POST',
        url: '/Usuario/EliminarUsuario',
        data: { 'IdUsuario': idUsuarioAux },
        dataType: 'json',
        async: false,
        success: function (data) {
            if (data.validar) {
                $("#modal-confirm-eliminacion-usuario").modal("show");
                idUsuarioAux = "";
                obtenerUsuarios();
            }
            else {
                $('#title-alert').text("Alerta");
                $('#body-alert').text('Problemas para eliminar al usuario seleccionado en la vista Administración de usuarios.');
                $("#modal-alerta").modal("show");
            }
        },
        error: function () {
            $('#title-alert').text("Alerta");
            $('#body-alert').text('Problemas para eliminar al usuario seleccionado en la vista Administración de usuarios.');
            $("#modal-alerta").modal("show");
        }
    });
}

function editarUsuario(idUsuario) {
    var usuario = usuarios.find(usuarioAux => usuarioAux.id == idUsuario);
    if (usuario != undefined || usuario != null) {
        idUsuarioAux = idUsuario;
        $("#email-editar").val(usuario.email);
        $("#nombre-editar").val(usuario.nombre);
        $("#cargo-editar").val(usuario.cargo);

        var cantRoles = roles.length;
        $('#rolUsuario-editar').empty().append('<option disabled value="-1">Seleccione el rol del usuario</option>');
        for (var i = 0; i < cantRoles; i++) {
            if (roles[i]["nombre"] == usuario.nombreRol) {
                $('#rolUsuario-editar').append("<option  value='" + roles[i]["id"] + "' selected>" + roles[i]["nombre"] + "</option>");
            }
            else {
                $('#rolUsuario-editar').append("<option  value='" + roles[i]["id"] + "'>" + roles[i]["nombre"] + "</option>");
            }
        }
        $("#modal-editar-usuario").modal("show");
    }
}

function guardarDatosPerfil() {

    var datos = {
        'IdUsuario': idUsuarioAux,
        'Email': $("#email-editar").val(),
        'Nombre': $("#nombre-editar").val(),
        'Cargo': $("#cargo-editar").val(),
        'RefRol': $('#rolUsuario-editar').val()
    }

    $.ajax({
        type: 'POST',
        url: '/Usuario/EditarPerfilUsuarios',
        data: datos,
        dataType: 'json',
        async: false,
        success: function (data) {
            if (data.validar) {
                $("#modal-editar-usuario").modal("hide");
                $("#modal-confirm-editar-perfil-final").modal("show");
                idUsuarioAux = "";
                obtenerUsuarios();
            }
        },
        error: function () {
            $('#title-alert').text("Alerta");
            $('#body-alert').text('Problemas con guardar los cambios del perfil de usuario en la vista Administración de usuarios.');
            $("#modal-alerta").modal("show");
        }
    });
}

function resetearCampos() {
    $("#email").val('');
    $("#nombre").val('');
    $("#cargo").val('');

    var cantRoles = roles.length;
    $('#rolUsuario').empty().append('<option disabled value="-1" selected>Seleccione el rol del usuario</option>');
    for (var i = 0; i < cantRoles; i++) {
        $('#rolUsuario').append("<option  value='" + roles[i]["id"] + "'>" + roles[i]["nombre"] + "</option>");
    }
}