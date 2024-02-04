// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$("#SubmitExam").on("click", function () {
    Swal.fire('Hello, Your Exam have submit successfully', 'success');
   
    window.location.href = '/Identity/Account/Logout';
    
});
$("#RegisterCandidate").on("click", function () {
    // Serialize the form data
    var formData = $("#RegisterCandidateForm").serialize();

    
    $.ajax({
        url: "/Accounts/RegisterCandidate",
        type: 'POST',
        data: formData,
        beforeSend: function () {
            //alert("Sending");
        },
        success: function (result) {
            Swal.fire('Hello, SweetAlert!', 'This is a simple alert!', 'success');
        },
        error: function () {
            alert('Error occurred while loading the next question.');
        }
    });
});

$("#Submit").on("click", function () {

    //var questionId = document.getElementById("questionId").value;
    
    $.ajax({
        url: "/Home/Easay",
        type: 'POST',
        //data: { currentQuestionId: questionId },
        beforeSend: function () {
            //alert("Sending");
        },
        success: function (result) {
            // Replace the content of the question container with the updated partial 
            window.location.href = '/Home/Easay';
        },
        error: function () {
            alert('Error occurred while loading the next question.');
        }
    });
});

function MoveToNextQuestion(){
    var questionId = document.getElementById("questionId").value;

    $.ajax({
        url: "/Home/MoveToNextQuestion",
        type: 'POST',
        data: { currentQuestionId: questionId },
        beforeSend: function () {
            //alert("Sending");
        },
        success: function (result) {
            // Replace the content of the question container with the updated partial view
            $('#questionContainer').html(result);
        },
        error: function () {
            alert('Error occurred while loading the next question.');
        }
    });
}


function MoveToPreviousQuestion() {
    var questionId = document.getElementById("questionId").value;
    $.ajax({
        url: "/Home/MoveToPreviousQuestion",
        type: 'POST',
        data: { currentQuestionId: questionId },
        beforeSend: function () {
            //alert("Sending");
        },
        success: function (result) {
            // Replace the content of the question container with the updated partial view
            $('#questionContainer').html(result);
        },
        error: function () {
            alert('Error occurred while loading the previous question.');
        }
    });
}
$("#prevBtn").on("click", function () {
    var questionId = document.getElementById("questionId").value;
    $.ajax({
        url: "/Home/MoveToPreviousQuestion",
        type: 'POST',
        data: { currentQuestionId: questionId },
        beforeSend: function () {
            //alert("Sending");
        },
        success: function (result) {
            // Replace the content of the question container with the updated partial view
            $('#questionContainer').html(result);
        },
        error: function () {
            alert('Error occurred while loading the previous question.');
        }
    });
});
/*function sideBtn() {
    alert("side");
    var questionId = $('.btnSd').val();

    alert(questionId);
    
}*/

$('.btnSd').on("click", function () {
    
    var questionId = $(this).val();
    $.ajax({
        url: "/Home/SelectedQuestion",
        type: 'POST',
        data: { currentQuestionId: questionId },
        beforeSend: function () {
            //alert("Sending");
        },
        success: function (result) {
            // Replace the content of the question container with the updated partial view
            $('#questionContainer').html(result);
        },
        error: function () {
            alert('Error occurred while loading the previous question.');
        }
    });
});


function submit() {
    // Perform any form validation or additional logic here

    $.ajax({
        type: "POST",
        url: "Home/Index",  // Replace with the actual URL to submit the form data
        data: $("#myForm").serialize(),  // Serialize form data
        success: function (response) {
            // Handle the response from the server
            console.log(response);
            MoveToPreviousQuestion();
            // Optionally, you can navigate to the next page or perform other actions after submission
            // For example, redirecting to another page:
            // window.location.href = '/nextPage';
        },
        error: function (error) {
            // Handle the error
            console.error(error);
        }
    });
}