window.onload = function () {
    listarProvincias();
}

var objGlobalProvincia;
async function listarProvincias() {

    objGlobalProvincia = {
        url: "Provincia/listarProvincias",
        divPintado: "divContenedor",
        cabeceras: ["Registro", "Codigo", "Nombre"],
        propiedades: ["registro", "codigo", "nombre"]
    }
    pintar(objGlobalProvincia)
}
