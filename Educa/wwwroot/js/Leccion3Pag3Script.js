document.getElementById("error-box").style.visibility = 'hidden';
let a = false;
let b = false;
let c = false;
let d = false;
let e = false;
let errorAudio = new Audio('/sounds/Leccion1/errorpag1.wav');
let aAudio = new Audio('/sounds/Leccion3/Pag3/Leccion3Pag3N.wav');
let eAudio = new Audio('/sounds/Leccion3/Pag3/Leccion3Pag3C.wav');
let iAudio = new Audio('/sounds/Leccion3/Pag3/Leccion3Pag3T.wav');
let oAudio = new Audio('/sounds/Leccion3/Pag3/Leccion3Pag3R.wav');
let uAudio = new Audio('/sounds/Leccion3/Pag3/Leccion3Pag3F.wav');

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

function Error(){
    document.getElementById("error-box").style.visibility = 'hidden';
}
function Siguiente(){
    if(a  && b  && c && d && e ){
        window.location = "/paginas/leccion3Pag4"
    } else{
        document.getElementById("error-box").style.visibility = 'visible';
        errorAudio.play();
    }
}