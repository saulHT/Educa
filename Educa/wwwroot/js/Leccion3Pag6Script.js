document.getElementById("container").style.visibility = 'hidden';
document.getElementById("title").style.visibility = 'hidden';
document.getElementById("error-box").style.visibility = 'hidden';
document.getElementById("end").style.visibility = 'hidden';
let a = false;
let b = false;
let c = false;
let d = false;
let e = false;
let startAudio = new Audio('/sounds/Leccion3/Pag6/Leccion3Pag6Intro.wav');
let errorAudio = new Audio('/sounds/Leccion1/errorpag1.wav');
let aAudio = new Audio('/sounds/Leccion3/Pag6/Leccion3Pag6X.wav');
let eAudio = new Audio('/sounds/Leccion3/Pag6/Leccion3Pag6W.wav');
function Inicio(){
    document.getElementById("container").style.visibility = 'visible';
    document.getElementById("title").style.visibility = 'visible'; 
    document.getElementById("end").style.visibility = 'visible';
    document.getElementById("success-box").style.visibility = 'hidden';
    startAudio.play();
}
function Play(num){
    switch (num) {
        
        case 0: 
            a = true;
            aAudio.play();
            break;
        case 1: 
            b = true;
            eAudio.play();
            break;
        
        default:
          console.log("default");
      }
}

function Error(){
    document.getElementById("error-box").style.visibility = 'hidden';
}
function Siguiente(){
    if(a  && b){
        window.location = "/paginas/leccion3Pag7"
    } else{
        document.getElementById("error-box").style.visibility = 'visible';
        errorAudio.play();
    }
}