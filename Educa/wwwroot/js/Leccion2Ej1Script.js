document.getElementById("success-box").style.visibility = 'hidden';
document.getElementById("error-box").style.visibility = 'hidden';
document.getElementById("container").style.visibility = 'hidden';
document.getElementById("title").style.visibility = 'hidden';
document.getElementById("info-box").style.visibility = 'visible';
let startAudio = new Audio('/sounds/Leccion2/Leccion2Ej1Intro.wav');
let winAudio = new Audio('/sounds/Leccion1/BienHecho.wav');
let loseAudio = new Audio('/sounds/Leccion1/BuenIntento.wav');
let puntos = 0;
let mostrarPuntos = document.getElementById('puntos');
let mostrarPuntos2 = document.getElementById('puntos2');
let link = null;
function Next() {
    window.location = link;
    /*/auth/login*/
}
function Inicio() {
    document.getElementById("container").style.visibility = 'visible';
    document.getElementById("title").style.visibility = 'visible';
    document.getElementById("info-box").style.visibility = 'hidden';
    startAudio.play();
}
//arreglo para saber cuales divs ya estan ocupados
let arreglo = ["", "", "", "", ""];

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
    if (arreglo[0] != "" && arreglo[1] != "" && arreglo[2] != "" && arreglo[3] != "" && arreglo[4]) {
        for (let i = 0; i < 5; i++) {
            switch (i) {
                case 0:
                    if (arreglo[i] == "u") {
                        puntos = puntos + 1;
                    }
                    break;
                case 1:
                    if (arreglo[i] == "e") {
                        puntos = puntos + 1;
                    }
                    break;
                case 2:
                    if (arreglo[i] == "a") {
                        puntos = puntos + 1;
                    }
                    break;
                case 3:
                    if (arreglo[i] == "i") {
                        puntos = puntos + 1;
                    }
                    break;
                case 4:
                    if (arreglo[i] == "o") {
                        puntos = puntos + 1;
                    }
                    break;
                default:
                    console.log("default");
            };
        }
        if (arreglo[0] == "u" && arreglo[1] == "e" && arreglo[2] == "a" && arreglo[3] == "i" && arreglo[4] == "o") {
            link = `/paginas/Leccion2Finish?puntos=${puntos}`;
            document.getElementById("success-box").style.visibility = 'visible';
            winAudio.play();
            mostrarPuntos.innerHTML = `Puntos: ${puntos}`;
        } else {
            link = `/paginas/Leccion2Finish?puntos=${puntos}}`;
            document.getElementById("error-box").style.visibility = 'visible';
            loseAudio.play();
            mostrarPuntos2.innerHTML = `Puntos: ${puntos}`;
        }
    }
}