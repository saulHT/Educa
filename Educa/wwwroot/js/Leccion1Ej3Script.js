document.getElementById("success-box").style.visibility = 'hidden';
document.getElementById("error-box").style.visibility = 'hidden';

document.getElementById("container").style.visibility = 'hidden';
document.getElementById("title").style.visibility = 'hidden';
document.getElementById("end").style.visibility = 'hidden';
document.getElementById("info-box").style.visibility = 'visible';
let startAudio = new Audio('/sounds/Leccion1/Leccion1Ej3Intro.wav');
let winAudio = new Audio('/sounds/Leccion1/BienHecho.wav');
let loseAudio = new Audio('/sounds/Leccion1/BuenIntento.wav');
let ceroAudio = new Audio('/sounds/Leccion1/cero.wav');
let unoAudio = new Audio('/sounds/Leccion1/uno.wav');
let dosAudio = new Audio('/sounds/Leccion1/dos.wav');
let tresAudio = new Audio('/sounds/Leccion1/tres.wav');
let cuatroAudio = new Audio('/sounds/Leccion1/cuatro.wav');
let cincoAudio = new Audio('/sounds/Leccion1/cinco.wav');
let seisAudio = new Audio('/sounds/Leccion1/seis.wav');
let sieteAudio = new Audio('/sounds/Leccion1/siete.wav');
let ochoAudio = new Audio('/sounds/Leccion1/ocho.wav');
let nueveAudio = new Audio('/sounds/Leccion1/nueve.wav');
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
let arreglo = ["", "", "", "", "", "", "", "", "", ""];

//funcion que evita que se abra como wenlace al soltar un elemento

function allowDrop(ev) {
    ev.preventDefault();
}
//que sucede cuando se arrastra un elemento
function drag(ev) {
    //metodo que establece el tip de datos y el valor de dato arrastrado en este casi el dato es texto 
    //y el valor es e lid del elemento arrastrado: "cero"
    ev.dataTransfer.setData("text", ev.target.id);
}

function drop(ev) {
    //Mediante ev.targewt.id tomo el nombre del id del div que puede ser del 0 al 9 si el arreglo en diah 
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
    if (arreglo[0] != "" && arreglo[1] != "" && arreglo[2] != "" && arreglo[3] != "" && arreglo[4] != "" && arreglo[5] != "" && arreglo[6] != "" && arreglo[7] != "" && arreglo[8] != "" && arreglo[9] != "") {
        if (arreglo[0] == "cinco" && arreglo[1] == "nueve" && arreglo[2] == "seis" && arreglo[3] == "uno" && arreglo[4] == "dos" && arreglo[5] == "cuatro" && arreglo[6] == "siete" && arreglo[7] == "tres" && arreglo[8] == "ocho" && arreglo[9] == "cero") {
            puntos = 5;
            link = `/paginas/Leccion1Finish?puntos=${puntos}`;
            document.getElementById("success-box").style.visibility = 'visible';
            document.getElementById("container-1").style.visibility = 'hidden';

            winAudio.play();
            

        } else {
            link = `/paginas/Leccion1Finish?puntos=${puntos}`;
            document.getElementById("error-box").style.visibility = 'visible';
            loseAudio.play();
        }
    }
}
function Next() {
    window.location = link;
}
function PlaySoundB(num) {
    switch (num) {

        case 0:
            ceroAudio.play();
            console.log(0);
            break;
        case 1:
            unoAudio.play();
            console.log(1);
            break;
        case 2:
            dosAudio.play();
            console.log(2);
            break;
        case 3:
            tresAudio.play();
            console.log(3);
            break;
        case 4:
            cuatroAudio.play();
            console.log(4);
            break;
        case 5:
            cincoAudio.play();
            console.log(5);
            break;
        case 6:
            seisAudio.play();
            console.log(6);
            break;
        case 7:
            sieteAudio.play();
            console.log(7);
            break;
        case 8:
            ochoAudio.play();
            console.log(8);
            break;
        case 9:
            nueveAudio.play();
            console.log(9);
            break;
        default:
            console.log("default");
    }
}