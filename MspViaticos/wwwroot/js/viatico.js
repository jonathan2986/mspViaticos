window.onload = function () {
    listarViaticos();
    /*validarKeyPress("frmGuardarDepartamento")*/
}

var objGlobalViatico;
async function listarViaticos() {

    objGlobalViatico = {
        popup: true,
        popupId: "staticBackdrop",
        url: "Viatico/listarViaticos",
        divPintado: "divContenedor",
        cabeceras: ["Numero", "Fecha", "Empleado","Provincia","Dependencia","Deartamento","Cargo","Sueldo","Metodo","Grupo","Comentario", "Tarifa","Fecha de Salida","Hora De Salida","Fecha Retorno","Hora Retorno","Provincia Enviado","Actividad","Desayuno","Almuerzo","Cena","Alojamiento","Total Dieta","Transporte","Total Viaje","Estatus"],
        propiedades: ["numero", "fecha", "nombreEmpleado", "provinciaNombre", "dependenciaNombre", "departamentoNombre", "cargoDescripcion", "sueldo", "metodoDescripcion", "grupoDescripcion", "comentario", "tarifa", "fechaSalida", "horaSalida", "fechaRetorno", "horaRetorno", "provinciaEnviadoNombre", "actividadDescripcion", "desayuno", "almuerzo", "cena", "alojamiento", "totalDieta", "transporte", "totalViaje","estatusDescripcion"],
        divContenedorTabla: "contenedorTabla",
        editar: true,
        eliminar: true,
        propiedadId: "registro",
        paginar: true
    }
    pintar(objGlobalViatico)
}