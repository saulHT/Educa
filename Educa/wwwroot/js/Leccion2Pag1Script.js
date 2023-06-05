
document.getElementById("info-box").style.visibility = 'visible';
document.getElementById("container").style.visibility = 'hidden';
document.getElementById("title-Top").style.visibility = 'hidden';
document.getElementById("end").style.visibility = 'hidden';
let startAudio = new Audio('/sounds/Leccion2/Leccion2Pag1Intro.wav');

function Inicio() {
    document.getElementById("container").style.visibility = 'visible';
    document.getElementById("title-Top").style.visibility = 'visible';
    document.getElementById("end").style.visibility = 'visible';
    document.getElementById("info-box").style.visibility = 'hidden';
    startAudio.play();
}
function Next() {
    window.location = "/paginas/leccion2Pag2"
    /*/auth/login*/
}