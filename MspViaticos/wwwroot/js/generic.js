﻿function get(idcontrol) {
    return document.getElementById(idcontrol).value;
}

function getI(idcontrol) {
    return document.getElementById(idcontrol).innerHTML;
}

function set(idcontrol, valor) {
    document.getElementById(idcontrol).value = valor;
}

function setI(idcontrol, valor) {
    document.getElementById(idcontrol).innerHTML = valor;
}

function setN(namecontrol, valor, idformulario) {
    if (idformulario == undefined) {
        document.getElementsByName(namecontrol)[0].value = valor;
    }
    else {
        document.querySelector("#" + idformulario + " [name='" + namecontrol + "']").value = valor;
    }

}

function recuperarGenerico(url, idformulario) {
    //Todos los elementos
    var elementosName = document.querySelectorAll("#" + idformulario + " [name]");
    var nombrename;
    fetchGet(url, "json", function (data) {
        for (var i = 0; i < elementosName.length; i++) {
            nombrename = elementosName[i].name;
            setN(nombrename, data[nombrename], idformulario)
        }
    });
}

function validarKeyPress(idformulario) {

    //Recorrimos todos los controles
    var elementosNames = document.querySelectorAll("#" + idformulario + " [name]");
    var control, nombreclases, clases, cantidad;
    var resultado;
    for (var i = 0; i < elementosNames.length; i++) {
        control = elementosNames[i];
        //form-control ob (Sacamos su clase completa)

        nombreclases = control.className;
        //["form-control","ob"]
        clases = nombreclases.split(" ");
        //Solo letras
        resultado = clases.filter(p => p == "sl")
        if (resultado.length > 0) {
            elementosNames[i].onkeypress = function (e) {
                //alert(String.fromCharCode(e.keyCode))
                //alert(e.target.value)
                var cadena = e.target.value + String.fromCharCode(e.keyCode)
                //alert(cadena)
                if (!/^[a-zA-Z]+$/.test(cadena)) {
                    e.preventDefault();
                }
                //if (String.fromCharCode(e.keyCode) == "5") {
                //    e.preventDefault();
                //}
            }
        }
        //Letras con espacio en blanco
        resultado = clases.filter(p => p == "slcenb")
        if (resultado.length > 0) {
            elementosNames[i].onkeypress = function (e) {
                var cadena = e.target.value + String.fromCharCode(e.keyCode)
                if (!/^[a-zA-Z ]+$/.test(cadena)) {
                    e.preventDefault();
                }
            }
        }
        //Solo numeros
        resultado = clases.filter(p => p == "sn")
        if (resultado.length > 0) {
            elementosNames[i].onkeypress = function (e) {
                var cadena = e.target.value + String.fromCharCode(e.keyCode)
                if (!/^[0-9]+$/.test(cadena)) {
                    e.preventDefault();
                }
            }
        }
        //Solo numeros , letras y espacios en blanco
        resultado = clases.filter(p => p == "snslcenb")
        if (resultado.length > 0) {
            elementosNames[i].onkeypress = function (e) {
                var cadena = e.target.value + String.fromCharCode(e.keyCode)
                if (!/^[a-zA-Z0-9 ]+$/.test(cadena)) {
                    e.preventDefault();
                }
            }
        }
    }
}



function ValidarDatos(idformulario) {
    var error = "";
    //Recorrimos todos los controles
    var elementosNames = document.querySelectorAll("#" + idformulario + " [name]");
    var control, nombreclases, clases, cantidad;
    var resultado;
    for (var i = 0; i < elementosNames.length; i++) {
        control = elementosNames[i];
        //form-control ob (Sacamos su clase completa)

        nombreclases = control.className;
        //["form-control","ob"]
        clases = nombreclases.split(" ");
        //Obligatorios
        resultado = clases.filter(p => p == "ob")
        if (resultado.length > 0) {
            if (control.value.trim() == "") {
                error = "Debe ingresar el campo " + control.name;
                return error;
            }
        }
        //Maximo
        resultado = clases.filter(p => p.includes("max-"))
        if (resultado.length > 0) {
            //max-100
            var nombreClaseConMax = resultado[0]
            //"100"
            var valorMaximo = nombreClaseConMax.replace("max-", "") * 1
            var longitudTexto = control.value.length
            if (longitudTexto > valorMaximo) {
                error = "El campo  " + control.name + " su longitud maxima es " + valorMaximo +
                    " y usted a escrito una cadena con longitud " + longitudTexto;
                return error;
            }
        }
        //Minimo
        resultado = clases.filter(p => p.includes("min-"))
        if (resultado.length > 0) {
            //max-100
            var nombreClaseConMin = resultado[0]
            //"100"
            var valorMinimo = nombreClaseConMin.replace("min-", "") * 1
            var longitudTexto = control.value.length
            if (longitudTexto < valorMinimo) {
                error = "El campo  " + control.name + " su longitud minima es " + valorMinimo +
                    " y usted a escrito una cadena con longitud " + longitudTexto;
                return error;
            }
        }
        //Solo letras
        resultado = clases.filter(p => p == "sl")
        if (resultado.length > 0) {
            if (!/^[a-zA-Z]+$/.test(control.value)) {
                error = "El campo " + control.name + " solo debe tener letras minusculas o mayusculas ";
                return error
            }
        }
        //Solo letras con espacio
        resultado = clases.filter(p => p == "slcenb")
        if (resultado.length > 0) {
            if (!/^[a-zA-Z ]+$/.test(control.value)) {
                error = "El campo " + control.name + " solo debe tener letras minusculas , mayusculas o espacio en blanco ";
                return error
            }
        }
        //Solo numeros
        resultado = clases.filter(p => p == "sn")
        if (resultado.length > 0) {
            if (!/^[0-9]+$/.test(control.value)) {
                error = "El campo " + control.name + " solo debe tener numeros del 0 al 9 ";
                return error
            }
        }
        //Solo numeros , letras y espacios en blanco
        resultado = clases.filter(p => p == "snslcenb")
        if (resultado.length > 0) {
            if (!/^[a-zA-Z0-9 ]+$/.test(control.value)) {
                error = "El campo " + control.name + " solo debe tener numeros , letras o espacios en blanco ";
                return error
            }
        }
    }
    return error;
}

function getN(namecontrol) {
    return document.getElementsByName(namecontrol)[0].value
}

function Error(titulo = "Error", texto = "Ocurrio un error") {
    Swal.fire({
        icon: 'error',
        title: titulo,
        text: texto
    })
}

function Confirmacion(titulo = "Confirmacion", texto = "Desea guardar los cambios?", callback) {
    return Swal.fire({
        title: titulo,
        text: texto,
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Si',
        cancelButtonText: "No"
    }).then((result) => {
        if (result.isConfirmed) {
            callback();
        }
    })
}

function Exito(titulo = "Se guardo correctamente") {
    Swal.fire({
        position: 'top-end',
        icon: 'success',
        title: titulo,
        showConfirmButton: false,
        timer: 1500
    })
}

function LimpiarDatos(idformulario) {
    var elementosName = document.querySelectorAll("#" + idformulario + " [name]");
    var elementoActual;
    var elementoName;
    for (var i = 0; i < elementosName.length; i++) {
        elementoActual = elementosName[i]
        elementoName = elementoActual.name;
        if (elementoActual.tagName.toUpperCase() == "SELECT") {
            document.getElementById(elementoActual.id).selectedIndex = 0;
        } else {
            setN(elementoName, "", idformulario);
        }

    }
}

async function fetchGet(url, tiporespuesta, callback) {
    try {
        var raiz = document.getElementById("hdfOculto").value;
        //http://localhost........
        var urlCompleta = window.location.protocol + "//" + window.location.host + "/" + raiz
            + url
        var res = await fetch(urlCompleta)
        if (tiporespuesta == "json")
            res = await res.json();
        else if (tiporespuesta == "text")
            res = await res.text();
        //JSON (Object)
        callback(res)

    } catch (e) {
        alert("Ocurrion un error");
    }
}
//[{"iidlaboratorio":1,"nombre":"SynLab","direccion":null,"personacontacto":null}
//, { "iidlaboratorio": 2, "nombre": "Multilab", "direccion": null, "personacontacto": null }, { "iidlaboratorio": 3, "nombre": "Suiza Lab", "direccion": null, "personacontacto": null }]
function llenarCombo(data, idcontrol, propiedadId, propiedadNombre, textoprimeraopcion = "--Seleccione--", valueprimeraopcion = "") {

    var contenido = "";
    var objActual;
    contenido += "<option value='" + valueprimeraopcion + "'>" + textoprimeraopcion + "</option>"
    for (var i = 0; i < data.length; i++) {
        objActual = data[i];
        contenido += "<option value='" + objActual[propiedadNombre] + "'>" + objActual[propiedadId] + "</option>"
    }
    /*setI(idcontrol, contenido)*/
    //document.getElementById(idcontrol).innerHTML = contenido;
    if (typeof (idcontrol) == "string") {
        /*contenido += "";*/
        setI(idcontrol, contenido)
    } else {
        for (var i = 0; i < idcontrol.length; i++) {
            /*contenido += "";*/
            setI(idcontrol[i], contenido)
        }
    }
}

async function fetchPost(url, tiporespuesta, frm, callback) {
    try {
        var raiz = document.getElementById("hdfOculto").value;
        //http://localhost........
        var urlCompleta = window.location.protocol + "//" + window.location.host + "/" + raiz + url
        var res = await fetch(urlCompleta, {
            method: "POST",
            body: frm
        });
        if (tiporespuesta == "json")
            res = await res.json();
        else if (tiporespuesta == "text")
            res = await res.text();
        //JSON (Object)
        callback(res)

    } catch (e) {
        console.log(e)
        alert("Ocurrion un error");
    }
}

//{url:"",columnas:[],propiedades:[]}

var objConfiguracionGlobal;

function pintar(objConfiguracion) {
    objConfiguracionGlobal = objConfiguracion;
    if (objConfiguracion.divContenedorTabla == undefined)
        objConfiguracion.divContenedorTabla = "divContenedorTabla"
    if (objConfiguracion.divPintado == undefined)
        objConfiguracion.divPintado = "divTabla"
    if (objConfiguracion.editar == undefined)
        objConfiguracion.editar = false
    if (objConfiguracion.eliminar == undefined)
        objConfiguracion.eliminar = false
    if (objConfiguracion.propiedadId == undefined)
        objConfiguracion.propiedadId = ""
    if (objConfiguracion.popup == undefined)
        objConfiguracion.popup = false

    fetchGet(objConfiguracion.url, "json", function (res) {
        var contenido = "";

        contenido += "<div id='" + objConfiguracion.divContenedorTabla + "'>";
        //........................................................
        contenido += generarTabla(res)
        contenido += "</div>"; 
        setI(objConfiguracion.divPintado, contenido)
        if (objConfiguracion.paginar == true) {
            $('#tabla').DataTable({
                "language": {
                    "processing": "Procesando...",
                    "lengthMenu": "Mostrar _MENU_ registros",
                    "zeroRecords": "No se encontraron resultados",
                    "emptyTable": "No se encontraron registros!!",
                    "infoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
                    "search": "Buscar:",
                    "loadingRecords": "Cargando...",
                    "paginate": {
                        "first": "Primero",
                        "last": "Último",
                        "next": "Siguiente",
                        "previous": "Anterior"
                    }
                }
            });
        }
        //  document.getElementById(objConfiguracion.divPintado).innerHTML = contenido;
    })


}

function generarTabla(res) {
    var contenido = "";
    //["Id tipo medicamento", "Nombre", "Descripcion"]
    var cabeceras = objConfiguracionGlobal.cabeceras;
    //: ["idtipomedicamento", "nombre","descripcion"]
    var nombrepropiedades = objConfiguracionGlobal.propiedades;
    contenido += "<table class='table mt-3' id='tabla'>";
    contenido += "<thead>";
    contenido += "<tr>";
    for (var i = 0; i < cabeceras.length; i++) {
        contenido += "<td>" + cabeceras[i] + "</td>";
    }
    //Una columna adicional (thead)
    if (objConfiguracionGlobal.editar == true || objConfiguracionGlobal.eliminar == true) {
        contenido += "<td>Operaciones</td>";
    }
    //contenido += "<td>Id tipo medicamento</td>";
    //contenido += "<td>Nombre</td>";
    //contenido += "<td>Descripcion</td>";
    contenido += "</tr>";
    contenido += "</thead>"

    var nregistros = res.length;
    var obj;
    var propiedadActual;
    contenido += "<tbody>";
    for (var i = 0; i < nregistros; i++) {
        obj = res[i]
        contenido += "<tr>";
        for (var j = 0; j < nombrepropiedades.length; j++) {
            propiedadActual = nombrepropiedades[j]
            contenido += "<td>" + obj[propiedadActual] + "</td>";
        }
        //Una columna adicional (tbody)
        if (objConfiguracionGlobal.editar == true || objConfiguracionGlobal.eliminar == true) {
            var propiedadId = objConfiguracionGlobal.propiedadId;
            contenido += "<td>";
            if (objConfiguracionGlobal.editar == true) {
                var tienepopup = objConfiguracionGlobal.popup
                contenido += `<i 
                        ${tienepopup == true ? `data-bs-toggle="modal" data-bs-target="#${objConfiguracionGlobal.popupId}" ` : ``}
                onclick="Editar(${obj[propiedadId]})" class="btn btn-primary"><svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-pen-fill" viewBox="0 0 16 16">
                <path d="m13.498.795.149-.149a1.207 1.207 0 1 1 1.707 1.708l-.149.148a1.5 1.5 0 0 1-.059 2.059L4.854 14.854a.5.5 0 0 1-.233.131l-4 1a.5.5 0 0 1-.606-.606l1-4a.5.5 0 0 1 .131-.232l9.642-9.642a.5.5 0 0 0-.642.056L6.854 4.854a.5.5 0 1 1-.708-.708L9.44.854A1.5 1.5 0 0 1 11.5.796a1.5 1.5 0 0 1 1.998-.001z" />
                  </svg ></i>`
            }
            if (objConfiguracionGlobal.eliminar == true) {
                contenido += `
             <i onclick="Eliminar(${obj[propiedadId]})" class="btn btn-danger"> <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" 
                  class="bi bi-trash-fill" viewBox="0 0 16 16">
                 <path d="M2.5 1a1 1 0 0 0-1 1v1a1 1 0 0 0 1 1H3v9a2 2 0 0 0 2 2h6a2 2 0 0 0 2-2V4h.5a1 1 0 0 0 1-1V2a1 1 0 0 0-1-1H10a1 1 0 0 0-1-1H7a1 1 0 0 0-1 1H2.5zm3 4a.5.5 0 0 1 .5.5v7a.5.5 0 0 1-1 0v-7a.5.5 0 0 1 .5-.5zM8 5a.5.5 0 0 1 .5.5v7a.5.5 0 0 1-1 0v-7A.5.5 0 0 1 8 5zm3 .5v7a.5.5 0 0 1-1 0v-7a.5.5 0 0 1 1 0z"/>
                        </svg></i>
            `
            }
            contenido += "</td>";
        }
        //contenido += "<td>" + obj[idtipomedicamento] + "</td>";
        //contenido += "<td>" + obj.[nombre] + "</td>";
        //contenido += "<td>" + obj.[descripcion] + "</td>";
        contenido += "</tr>";
    }
    contenido += "</tbody>"
    contenido += "</table>";
    return contenido;
}