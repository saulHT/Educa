document.getElementById("content").style.visibility = 'hidden';
document.getElementById("end").style.visibility = 'hidden';
document.getElementById("success-box").style.visibility = 'visible';

let startAudio = new Audio('/sounds/Leccion4/Pag2/Leccion4Pag2Intro.wav');

function Inicio(){
    document.getElementById("container").style.visibility = 'visible';
    document.getElementById("content").style.visibility = 'visible'; 
    document.getElementById("end").style.visibility = 'visible';
    document.getElementById("success-box").style.visibility = 'hidden';
    startAudio.play();
}
function Next(){
    window.location = "/paginas/Leccion4Pag3"
    /*/auth/login*/
}