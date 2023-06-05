document.getElementById("container").style.visibility = 'hidden';
document.getElementById("title").style.visibility = 'hidden';
document.getElementById("error-box").style.visibility = 'hidden';
document.getElementById("end").style.visibility = 'hidden';
let a = false;
let b = false;
let c = false;
let d = false;
let e = false;
let startAudio = new Audio('/sounds/Leccion2/Leccion2Pag2Intro.wav');
let errorAudio = new Audio('/sounds/Leccion1/errorpag1.wav');
let aAudio = new Audio('/sounds/Leccion2/VocalCa.wav');
let eAudio = new Audio('/sounds/Leccion2/VocalCe.wav');
let iAudio = new Audio('/sounds/Leccion2/VocalCi.wav');
let oAudio = new Audio('/sounds/Leccion2/VocalCo.wav');
let uAudio = new Audio('/sounds/Leccion2/VocalCu.wav');
function Inicio() {
    document.getElementById("container").style.visibility = 'visible';
    document.getElementById("title").style.visibility = 'visible';
    document.getElementById("end").style.visibility = 'visible';
    document.getElementById("success-box").style.visibility = 'hidden';
    startAudio.play();
}
function Play(num) {
    switch (num) {

        case 0:
            a = true;
            aAudio.play();
            break;
        case 1:
            b = true;
            eAudio.play();
            break;
        case 2:
            c = true;
            iAudio.play();
            break;
        case 3:
            d = true;
            oAudio.play();
            break;
        case 4:
            e = true;
            uAudio.play();
            break;
        default:
            console.log("default");
    }
}

function Error() {
    document.getElementById("error-box").style.visibility = 'hidden';
}
function Siguiente() {
    if (a && b && c && d && e) {
        window.location = "/paginas/leccion2Ej1"
    } else {
        document.getElementById("error-box").style.visibility = 'visible';
        errorAudio.play();
    }
}