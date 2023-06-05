//
// lib/lib.js
//
document.getElementById("error-box").style.visibility = 'hidden';
document.getElementById("info-box").style.visibility = 'visible';
let rightAudio = new Audio('/sounds/win2.wav');
let wrongAudio = new Audio('/sounds/wrong2.wav');
let winAudio = new Audio('/sounds/FinishQuestion.wav');
let startAudio = new Audio('/sounds/Leccion4/Ej2/Leccion4Ej2Intro.wav');
let mostrarPuntos = document.getElementById('puntos');
let link = null;
let puntos = 0;
function Inicio(){
  document.getElementById("info-box").style.visibility = 'hidden';
  startAudio.play();
}
var Question = function (questionObj) {
  this.value = {
    text: "Question",
    answers: []
  };

  this.selectedAnswer = null;
  this.html = null;
  this.questionText = null;
  this.questionAnswers = null;
  this.questionFeedback = null;

  this.value = Object.assign(this.value, questionObj);

  this.onQuestionAnswered = ({ detail }) => {
    this.selectedAnswer = {
      value: detail.answer,
      html: detail.answerHtml
    };
    this.update();

    document.dispatchEvent(
      new CustomEvent("question-answered", {
        detail: {
          question: this,
          answer: detail.answer
        }
      })
    );
  };

  this.create = function () {
    this.html = document.createElement("div");
    this.html.classList.add("question");

    this.questionText = document.createElement("h2");
    this.questionText.textContent = this.value.text;

    this.questionAnswers = document.createElement("div");
    this.questionAnswers.classList.add("answers");

    for (let i = 0; i < this.value.answers.length; i++) {
      const ansObj = this.value.answers[i];
      let answer = createAnswer(ansObj);

      answer.onclick = (ev) => {
        if (this.selectedAnswer !== null) {
          this.selectedAnswer.html.classList.remove("selected");
        }

        answer.classList.add("selected");

        this.html.dispatchEvent(
          new CustomEvent("question-answered", {
            detail: {
              answer: ansObj,
              answerHtml: answer
            }
          })
        );
      };

      this.questionAnswers.appendChild(answer);
    }

    this.questionFeedback = document.createElement("div");
    this.questionFeedback.classList.add("question-feedback");

    this.html.appendChild(this.questionText);
    this.html.appendChild(this.questionAnswers);
    this.html.appendChild(this.questionFeedback);

    this.html.addEventListener("question-answered", this.onQuestionAnswered);

    return this.html;
  };

  this.disable = function () {
    this.html.classList.add("disabled");
    this.html.onclick = (ev) => {
      ev.stopPropagation();
    };

    this.html.removeEventListener("question-answered", this.onQuestionAnswered);

    let answers = this.html.querySelectorAll(".answer");
    for (let i = 0; i < answers.length; i++) {
      let answer = answers[i];
      answer.onclick = null;
    }
  };

  this.remove = function () {
    let children = this.html.querySelectorAll("*");
    for (let i = 0; i < children.length; i++) {
      const child = children[i];
      this.html.removeChild(child);
    }

    this.html.removeEventListener("question-answered", this.onQuestionAnswered);

    this.html.parentNode.removeChild(this.html);
    this.html = null;
  };

  this.update = function () {
    let correctFeedback, incorrectFeedback;
    this.html = this.html || document.createElement("div");

    correctFeedback = "La acertaste.";
    incorrectFeedback = "Oh no!, no la acertaste..";

    if (this.selectedAnswer !== null) {
      if (this.selectedAnswer.value.isCorrect) {
        this.html.classList.add("correct");
        this.html.classList.remove("incorrect");
        this.questionFeedback.innerHTML = correctFeedback;
        rightAudio.play();
      } else {
        this.html.classList.add("incorrect");
        this.html.classList.remove("correct");
        this.questionFeedback.innerHTML = incorrectFeedback;
        wrongAudio.play();
      }
    }
  };

  function createAnswer(obj) {
    this.value = {
      text: "Answer",
      isCorrect: false
    };

    this.value = Object.assign(this.value, obj);

    this.html = document.createElement("button");
    this.html.classList.add("answer");

    this.html.textContent = this.value.text;

    return this.html;
  }
};

//
// main.js
//

let questionsData = [
  {
    text: "mi tía berta quiere ir a casa de su amigo hugo.",
    answers: [
      {
        text: "Correcto",
        isCorrect: false
      },
      {
        text: "Incorrecto",
        isCorrect: true
      }
    ]
  },
  {
    text: "Cajamarca es una ciudad que se encuentra en Perú.",
    answers: [
      {
        text: "Correcto",
        isCorrect: true
      },
      {
        text: "Incorrecto",
        isCorrect: false
      }
    ]
  },
  {
    text: "nieves come cerezas con sofía.",
    answers: [
      {
        text: "Correcto",
        isCorrect: false
      },
      {
        text: "Incorrecto",
        isCorrect: true
      }
    ]
  },
  {
    text: "Tengo una perrita que se llama Era y es muy traviesa.",
    answers: [
      {
        text: "Correcto",
        isCorrect: true
      },
      {
        text: "Incorrecto",
        isCorrect: false
      }
    ]
  },
  {
    text: "Me gusta mucho ir a Barcelona",
    answers: [
      {
        text: "Correcto",
        isCorrect: true
      },
      {
        text: "Incorrecto",
        isCorrect: false
      }
    ]
  },
  {
    text: "Hoy he visitado a mis amigos daniel y sara, los dos viven en Cajamarca.",
    answers: [
      {
        text: "Correcto",
        isCorrect: false
      },
      {
        text: "Incorrecto",
        isCorrect: true
      }
    ]
  }
];

// variables initialization
let questions = [];
let score = 0,
  answeredQuestions = 0;
let appContainer = document.getElementById("questions-container");
let scoreContainer = document.getElementById("score-container");
scoreContainer.innerHTML = `Puntos: ${score}/${questionsData.length}`;

/**
 * Shuffles array in place. ES6 version
 * @param {Array} arr items An array containing the items.
 */
function shuffle(arr) {
  for (let i = arr.length - 1; i > 0; i--) {
    const j = Math.floor(Math.random() * (i + 1));
    [arr[i], arr[j]] = [arr[j], arr[i]];
  }
}

shuffle(questionsData);

// creating questions
for (var i = 0; i < questionsData.length; i++) {
  let question = new Question({
    text: questionsData[i].text,
    answers: questionsData[i].answers
  });

  appContainer.appendChild(question.create());
  questions.push(question);
}

document.addEventListener("question-answered", ({ detail }) => {
  if (detail.answer.isCorrect) {
    score++;
  }

  answeredQuestions++;
  scoreContainer.innerHTML = `Puntos: ${score}/${questions.length}`;
  detail.question.disable();

  if (answeredQuestions == questions.length) {
    setTimeout(function () {
      puntos = score;
      link = `/paginas/Leccion4Finish?puntos=${puntos}`;
      winAudio.play();
      mostrarPuntos.innerHTML = `Puntos: ${puntos}`;
      document.getElementById("error-box").style.visibility = 'visible';
    }, 100);
  }
});

console.log(questions, questionsData);
function Next(){
   window.location = link;
}