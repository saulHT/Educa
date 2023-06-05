document.getElementById("uno").style.visibility = 'hidden';
document.getElementById("dos").style.visibility = 'hidden';
document.getElementById("end").style.visibility = 'hidden';
document.getElementById("title").style.visibility = 'hidden';
document.getElementById("success-box").style.visibility = 'hidden';
document.getElementById("error-box").style.visibility = 'hidden';
document.getElementById("info-box").style.visibility = 'visible';
//Inicializacion de variables
let tarjetasDestapadas = 0;
let tarjeta1 = null;
let tarjeta2 = null;
let primerResultado = null;
let segundoResultado = null;
let movimientos = 0;
let aciertos = 0;
let Totalaciertos = 8;
let temporizador = false;
let timer = 60;
let timerInicial = timer;
let tiempoRegresivoId = null;
let link = null;

let winAudio = new Audio('/sounds/win.wav');
let loseAudio = new Audio('/sounds/lose.wav');
let clickAudio = new Audio('/sounds/click.wav');
let rightAudio = new Audio('/sounds/right.wav');
let wrongAudio = new Audio('/sounds/wrong.wav');
let startAudio = new Audio('/sounds/Leccion1/Leccion1Ej2Intro.wav')

//Apuntando a documento HTML
let mostrarMovimientos = document.getElementById('movimientos');
let mostrarAciertos = document.getElementById('aciertos');
let mostrarTiempo = document.getElementById('t-restante');

// Generacion de numeros aleatorios
let numeros = [1, 9, 2, 18, 3, 27, 4, 36, 5, 45, 6, 54, 7, 63, 8, 72];
numeros = numeros.sort(() => { return Math.random() - 0.5 });
console.log(numeros);

//funciones
function Inicio() {
    document.getElementById("uno").style.visibility = 'visible';
    document.getElementById("dos").style.visibility = 'visible';
    document.getElementById("end").style.visibility = 'visible';
    document.getElementById("title").style.visibility = 'visible';
    document.getElementById("info-box").style.visibility = 'hidden';
    startAudio.play();
}
function Next() {
    window.location = link;
}

function contarTiempo() {
    tiempoRegresivoId = setInterval(() => {
        mostrarTiempo.innerHTML = `Tiempo: ${timer} segundos`;
        timer--;
        if (timer < 0) {
            clearInterval(tiempoRegresivoId);
            bloquearTarjetos();
            loseAudio.play();
            clearInterval(tiempoRegresivoId);
            mostrarAciertos.innerHTML = `&#128557; Te faltaron ${Totalaciertos - aciertos} para ganar`;
            link = `/paginas/leccion1Ej3?puntos=0`
            document.getElementById("error-box").style.visibility = 'visible';
        }
    }, 1000, timer);
}
function bloquearTarjetos() {
    for (let i = 0; i <= 15; i++) {
        let tarjetaBloqueada = document.getElementById(i);
        tarjetaBloqueada.innerHTML = `<img src="/Images/Leccion/Leccion1/EJ2/${numeros[i]}.png" alt="">`;
        tarjetaBloqueada.disabled = true;
    }
}

// funcion Principal
function destapar(id) {
    if (temporizador == false) {
        contarTiempo();
        temporizador = true;
    }


    if (tarjetasDestapadas == 0) {
        //mostrar primer numero
        tarjeta1 = document.getElementById(id);
        primerResultado = numeros[id];
        tarjeta1.innerHTML = `<img src="/Images/Leccion/Leccion1/EJ2/${primerResultado}.png" alt="">`;
        clickAudio.play();

        //Deshabilitar primer boton
        tarjeta1.disabled = true;
        tarjetasDestapadas++;

    } else if (tarjetasDestapadas == 1) {
        //Mostrar segundo numero
        tarjeta2 = document.getElementById(id);
        segundoResultado = numeros[id];
        tarjeta2.innerHTML = `<img src="/Images/Leccion/Leccion1/EJ2/${segundoResultado}.png" alt="">`,

            //Deshabilitar primer boton
            tarjeta2.disabled = true;
        tarjetasDestapadas++;

        //incrementar movimientos
        movimientos++;
        mostrarMovimientos.innerHTML = `Movimientos: ${movimientos}`;

        if (primerResultado == segundoResultado * 9 || segundoResultado == primerResultado * 9) {
            // Recetear contador tarjetas destapadas
            tarjetasDestapadas = 0;
            rightAudio.play();
            //Aumentar aciertos
            aciertos++;
            mostrarAciertos.innerHTML = `Aciertos: ${aciertos}`;

        } else {
            //Mostrar momentaneamente valores y volver a tapar
            wrongAudio.play();

            setTimeout(() => {
                tarjeta1.innerHTML = ' ';
                tarjeta2.innerHTML = ' ';
                tarjeta1.disabled = false;
                tarjeta2.disabled = false;
                tarjetasDestapadas = 0;
            }, 800);
        }
    }
    if (aciertos == 8) {
        winAudio.play();
        clearInterval(tiempoRegresivoId);
        mostrarAciertos.innerHTML = `Aciertos: ${aciertos} &#128561;`;
        mostrarTiempo.innerHTML = `Excelente! &#127882; Tardaste ${timerInicial - timer} segundos &#8987;`;
        mostrarMovimientos.innerHTML = `Movimientos: ${movimientos} &#127776;`;
        link = `/paginas/leccion1Ej3?puntos=5`
        document.getElementById("success-box").style.visibility = 'visible';

    }


}
