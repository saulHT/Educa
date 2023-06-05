document.getElementById("content").style.visibility = 'hidden';
document.getElementById("end").style.visibility = 'hidden';
document.getElementById("error-box").style.visibility = 'hidden';
document.getElementById("success-box").style.visibility = 'visible';

let startAudio = new Audio('/sounds/Leccion4/Pag3/Leccion4Pag3Intro.wav');
let aAudio = new Audio('/sounds/Leccion4/Pag3/Leccion4Pag3NP.wav');
let eAudio = new Audio('/sounds/Leccion4/Pag3/Leccion4Pag3DP.wav');
let iAudio = new Audio('/sounds/Leccion4/Pag3/Leccion4Pag3S.wav');
let oAudio = new Audio('/sounds/Leccion4/Pag3/Leccion4Pag3O.wav');
let errorAudio = new Audio('/sounds/Leccion1/errorpag1.wav');
let a = false;
let e = false;
let i = false;
let o = false;

function Inicio(){
    document.getElementById("container").style.visibility = 'visible';
    document.getElementById("content").style.visibility = 'visible'; 
    document.getElementById("end").style.visibility = 'visible';
    document.getElementById("success-box").style.visibility = 'hidden';
    startAudio.play();
}
function Error(){
    document.getElementById("error-box").style.visibility = 'hidden';
}
function Next(){
    if(a  && e && i && o ){
        window.location = "/paginas/Leccion4Ej1";
    /*/auth/login*/
    }else{
        document.getElementById("error-box").style.visibility = 'visible';
        errorAudio.play();
    }
    
}
function Sound(num){
    switch (num) {
        case 0: 
            a = true;
            aAudio.play();
            break;
        case 1: 
            e = true;
            eAudio.play();
            break;
        case 2: 
            i = true;
            iAudio.play();
            break;
        case 3: 
            o = true;
            oAudio.play();
            break;
        default:
          console.log("default");
      }
}