// Author: Sasha Andersen
// Date created: 22/06/2022
/* Overview: 
- Event listeners created at the top to easily reference and reduce long code. All link to another function below 
- Language function to display text depending on which button is clicked.
- validateInsert function to check all number fields are within input constraints before passing to insert function
- Insert function to insert the object to the canvas with the inputted formats.
- Clear function to clear the canvas with a blank rectangle
- validatePassword function to check if password and confirm password inputs match.
*/

document.querySelector("#engButton").addEventListener('click', function(){ language("english")});
document.querySelector("#spaButton").addEventListener('click', function(){ language("spanish")});
document.querySelector("#insertBtn").addEventListener('click', validateInsert);document.querySelector("#clearBtn").addEventListener('click', clear);
document.querySelector("#cnfpwd").addEventListener('change', validatePassword);

function language (x){
    if(x === "english") {
        document.querySelector("#heading").innerHTML = "Abstract Art Competition";
        document.querySelector("#heading").style.color = "rgb(150, 115, 166)";
        document.querySelector("#para").innerHTML = "To create your artwork, select and insert various objects from the panel.<br>Start by clicking on the dropdown menu below to select your object, then select the outline colour.<br>According to your selected object input the size, fill colour and location details.<br>Click on the 'Insert' button to create your object on the canvas.<br>Repeat steps above until completed.";
    }
    if(x === "spanish") {
        document.querySelector("#heading").innerHTML = "Concurso de Arte Abstracto";
        document.querySelector("#heading").style.color = "blue";
        document.querySelector("#para").innerHTML = "Para crear su obra de arte, seleccione e inserte varios objetos del panel de la izquierda.<br>Comience haciendo clic en el menú desplegable a continuación para seleccionar su objeto, luego seleccione el color del contorno.<br>De acuerdo con el objeto seleccionado, ingrese el tamaño, el color de relleno y los detalles de ubicación.<br>Haga clic en el botón 'Insertar' para crear su objeto en el lienzo.<br>Repita los pasos anteriores hasta completarlos.";
    }
}

function validateInsert(event) {
    // Check all number fields are within input constraints before passing to insert function
    if(document.querySelector("#objects").value === "circle") {
        const Xcircle = document.getElementById("XcoordC");
        const Ycircle = document.getElementById("YcoordC");
        if (Xcircle.checkValidity() && Ycircle.checkValidity()) {
            insert();
        }
        else {
            alert('Number is out of range (0-400)');
            event.preventDefault();
        }
    }
    else if(document.querySelector("#objects").value === "sprayCircles") {
        const XsCircle = document.getElementById("XcoordC");
        const YsCircle = document.getElementById("YcoordC");
        if(XsCircle.checkValidity() && YsCircle.checkValidity()) {
            insert();
        }
        else {
            alert('Number is out of range (0-400)');
            event.preventDefault();
        }
    }
    else if(document.querySelector("#objects").value === "rectangle") {
        const heightRect = document.getElementById("height");
        const widthRect = document.getElementById("width");
        const Xrect = document.getElementById("XcoordR");
        const Yrect = document.getElementById("YcoordR");
        if(heightRect.checkValidity() && widthRect.checkValidity() && Xrect.checkValidity() && Yrect.checkValidity()) {
            insert();
        }
        else {
            alert('Number is out of range');
            event.preventDefault();
        }
    }
    else if(document.querySelector("#objects").value === "line") {
        const XstaLine = document.getElementById("xStart");
        const XendLine = document.getElementById("xEnd");
        const YstaLine = document.getElementById("yStart");
        const YendLine = document.getElementById("yEnd");
        if(XstaLine.checkValidity() && XendLine.checkValidity() && YstaLine.  checkValidity() && YendLine.checkValidity()) {
            insert();
        }
        else {
            alert('Number is out of range (0-400)');
            event.preventDefault();
        }
    }
}

function insert() {
    let canvas = document.getElementById("abstractCanvas");
    let ctx = canvas.getContext("2d");
    
    if(document.querySelector("#objects").value === "circle") {
        ctx.beginPath();
        ctx.arc(
            document.getElementById("XcoordC").value,
            document.getElementById("YcoordC").value,
            document.getElementById("radius").value,
            0,2*Math.PI);
        ctx.strokeStyle = document.getElementById("outlineColor").value;
        ctx.lineWidth = 3;
        ctx.stroke();
        ctx.arc(
            document.getElementById("XcoordC").value,
            document.getElementById("YcoordC").value,
            document.getElementById("radius").value,
            0,2*Math.PI);
        ctx.fillStyle = document.getElementById("fillColorC").value;
        ctx.fill();
    }
    else if(document.querySelector("#objects").value === "sprayCircles") {
        let circleX = (document.getElementById("XcoordC").value);
        let circleY = (document.getElementById("YcoordC").value);
        function circles(){
            ctx.beginPath();
            ctx.arc(circleX, circleY, document.getElementById("radius").value,0,2*Math.PI);
            ctx.strokeStyle = document.getElementById("outlineColor").value;
            ctx.lineWidth = 3;
            ctx.stroke();
            ctx.arc(circleX, circleY, document.getElementById("radius").value,0,2*Math.PI);
            ctx.fillStyle = document.getElementById("fillColorC").value;
            ctx.fill();
        }
        for(y = 0; y < 5; y++) {
            // insert first formatted circle then repeat 5 times at random coordinates.
            circles();
            circleX = Math.floor(Math.random() * 400)+10;
            circleY = Math.floor(Math.random() * 400)+10;
        }
    }
    else if(document.querySelector("#objects").value === "rectangle") {
        ctx.beginPath();
        ctx.rect(
            document.getElementById("XcoordR").value, 
            document.getElementById("YcoordR").value, 
            document.getElementById("width").value, 
            document.getElementById("height").value);
        ctx.strokeStyle = document.getElementById("outlineColor").value;
        ctx.lineWidth = 3;
        ctx.stroke();
        ctx.rect(
            document.getElementById("XcoordR").value, 
            document.getElementById("YcoordR").value, 
            document.getElementById("width").value, 
            document.getElementById("height").value);
        ctx.fillStyle = document.getElementById("fillColorR").value;
        ctx.fill();
    }
    else if(document.querySelector("#objects").value === "line") {
        ctx.beginPath();
        ctx.moveTo(
            document.getElementById("xStart").value, 
            document.getElementById("yStart").value);
        ctx.lineTo(
            document.getElementById("xEnd").value, 
            document.getElementById("yEnd").value);
        ctx.strokeStyle = document.getElementById("outlineColor").value;
        ctx.lineWidth = 3;
        ctx.stroke();
    }
}

function clear() {
    clearRect(0, 0, 400, 400);
}

function validatePassword() {
  if(document.querySelector("#pwd").value != document.querySelector("#cnfpwd").value) {
    document.querySelector("#cnfpwd").setCustomValidity("Passwords don't match");
    document.querySelector("#cnfpwd").reportValidity();
    document.querySelector("#pwd").value ='';
    document.querySelector("#cnfpwd").value ='';
  } 
  else {
    document.querySelector("#cnfpwd").setCustomValidity('');
    document.querySelector("#cnfpwd").reportValidity();
  } 
}