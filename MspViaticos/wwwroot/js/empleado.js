window.onload = function () {
    listarEmpleados();
    listarCombo();
}

var objGlobalEmpleado;
async function listarEmpleados() {

    objGlobalEmpleado = {
        popup: true,
        popupId: "staticBackdrop",
        url: "Empleado/listarEmpleados",
        divPintado: "divContenedor",
        cabeceras: ["Codigo", "Nombre", "Cedula", "Provincia", "Dependencia", "Departamento", "Cargo", "Sueldo", "Estatus"],
        propiedades: ["codigo", "nombre", "cedula", "provinciaNombre", "dependenciaNombre", "departamentoNombre", "cargoDescripcion", "sueldo","estatusDescripcion"],
        divContenedorTabla: "contenedorTabla",
        editar: true,
        eliminar: true,
        propiedadId: "registro",
        paginar: true
    }
    pintar(objGlobalEmpleado)
}

function listarCombo() {
    fetchGet("Empleado/listarCombos", "json", function (res) {

        console.log(res);
        var listaProvincia = res.listaProvincia;
        var listaDependencia = res.listaDependencia;
        var listaDepartamento = res.listaDepartamento;
        var listaCargo = res.listaCargo;

        llenarCombo(listaProvincia, ["cboProvincia"], "nombre", "codigo", "--Todos--", "0")
        llenarCombo(listaDependencia, ["cboDependencia"], "nombre", "codigo", "--Todos--", "0")
        llenarCombo(listaDepartamento, ["cboDepartamento"], "nombre", "codigo", "--Todos--", "0")
        llenarCombo(listaCargo, ["cboCargo"], "descripcion", "codigo", "--Todos--", "0")
    })
}

function GuardarDatos() {

    var errores = ValidarDatos("frmGuardarEmpleado")
    if (errores != "") {
        Error(errores)
        return;
    }

    var frmGuardar = document.getElementById("frmGuardarEmpleado")
    var frm = new FormData(frmGuardar);
    Confirmacion(undefined, "Desea guardar un empleado?", function () {
        fetchPost("Empleado/guardarEmpleado", "text", frm, function (data) {
            if (data == "1") {
                Exito();
                listarEmpleados()
                LimpiarDatos("frmGuardarEmpleado");
            } else Error();
        })
    })
}

function Editar(registro) {
    LimpiarDatos("frmGuardarEmpleado");
    if (registro == 0) {
        setI("lblTitulo", "Agregar Empleado")
    } else {
        setI("lblTitulo", "Editar Empleado")
        recuperarGenerico("Empleado/recuperarEmpleado/?registro=" + registro, "frmGuardarEmpleado")
    }

}
