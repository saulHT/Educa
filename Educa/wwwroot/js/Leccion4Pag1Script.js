document.getElementById("content").style.visibility = 'hidden';
document.getElementById("end").style.visibility = 'hidden';
document.getElementById("success-box").style.visibility = 'visible';

let startAudio = new Audio('/sounds/Leccion4/Pag1/Leccion4Pag1Intro.wav');

function Inicio(){
    document.getElementById("container").style.visibility = 'visible';
    document.getElementById("content").style.visibility = 'visible'; 
    document.getElementById("end").style.visibility = 'visible';
    document.getElementById("success-box").style.visibility = 'hidden';
    startAudio.play();
}
function Next(){
    window.location = "/paginas/Leccion4Pag2"
    /*/auth/login*/
}