document.getElementById("success-box").style.visibility = 'hidden';
document.getElementById("error-box").style.visibility = 'hidden';
document.getElementById("info-box").style.visibility = 'visible';
document.getElementById("container").style.visibility = 'hidden';
document.getElementById("title").style.visibility = 'hidden';
document.getElementById("end").style.visibility = 'hidden';
let startAudio = new Audio('/sounds/Leccion1/Leccion1Ej1Intro.wav');
let winAudio = new Audio('/sounds/Leccion1/BienHecho.wav');
let loseAudio = new Audio('/sounds/Leccion1/BuenIntento.wav');
let puntos = 0;
let link = null;

function Inicio() {
    document.getElementById("container").style.visibility = 'visible';
    document.getElementById("title").style.visibility = 'visible';
    document.getElementById("end").style.visibility = 'visible';
    document.getElementById("info-box").style.visibility = 'hidden';
    startAudio.play();
}
//arreglo para saber cuales divs ya estan ocupados
let arreglo = ["", ""];

//funcion que evita que se abra como wenlace al soltar un elemento

function allowDrop(ev) {
    ev.preventDefault();
}
//que sucede cuando se arrastra un elemento
function drag(ev) {
    //metodo que establece el tip de datos y el valor de dato arrastrado en este casi el dato es texto 
    //y el valor es e lid del elemento arrastrado: "nueve"
    ev.dataTransfer.setData("text", ev.target.id);
}

function drop(ev) {
    //Mediante ev.targewt.id tomo el nombre del id del div que puede ser del 0 al 1 si el arreglo en diah 
    //esta vacio, significa que no tiene nada, osea puedo soltar ahi, delo contrario esta ocupado por otro elemento
    if (arreglo[parseInt(ev.target.id)] == "") {
        //obtengo los datos arrastrados con el metodo dataTransfer.getData(). este metodo devolvera cualquier dato 
        //que se haya establecidoen el mismo tipo en metodo setData(),En este ejemplo data quedara con nueve o cinco
        var data = ev.dataTransfer.getData("text");
        //agrego al arreglo el nombre del id
        arreglo[parseInt(ev.target.id)] = data;
        //agrego el elemento arrastrado al elemnto soltado
        ev.target.appendChild(document.getElementById(data));
    }
    if (arreglo[0] != "" && arreglo[1] != "") {
        if (arreglo[0] == "cinco" && arreglo[1] == "nueve") {
            document.getElementById("success-box").style.visibility = 'visible';
            winAudio.play();
            puntos = 5;
            link = `/paginas/leccion1Ej2?puntos=${puntos}`;

        } else {
            document.getElementById("error-box").style.visibility = 'visible';
            loseAudio.play();
            link = `/paginas/leccion1Ej2?puntos=${puntos}`;
        }
    }
}
function Next() {
    window.location = link;

}