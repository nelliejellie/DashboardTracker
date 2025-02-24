document.addEventListener("DOMContentLoaded", function () {
    console.log("hello");

    var jobDetailsModal = document.getElementById('jobDetailsModal');

    jobDetailsModal.addEventListener('hidden.bs.modal', function () {
        var modalBackdrop = document.querySelector('.modal-backdrop');
        if (modalBackdrop) {
            modalBackdrop.remove(); // Remove lingering backdrop
        }
        document.body.classList.remove('modal-open'); // Ensure scrolling is restored
        document.body.style.paddingRight = ''; // Remove any Bootstrap-added padding
    });



    // Select all cards
    document.querySelectorAll('.carder').forEach(function (card) {
        card.addEventListener('click', function () {
            // Retrieve data attributes from the clicked card
            var jobName = card.getAttribute('data-name');
            var appName = card.getAttribute('data-appname');
            var jobUrl = card.getAttribute('data-joburl');
            var jobInterval = card.getAttribute('data-interval');
            var jobStatus = card.getAttribute('data-status');
            var doNotification = card.getAttribute('data-donotification');
            var doNotificationEmail = card.getAttribute('data-donotificationemail');
            var doNotificationEmailCC = card.getAttribute('data-donotificationemailcc');
            var doNotificationEmailBCC = card.getAttribute('data-donotificationemailbcc');
            var repeatUntilSuccess = card.getAttribute('data-repeatuntilsuccess');
            var lastRun = card.getAttribute('data-lastrun');
            var nextRun = card.getAttribute('data-nextrun');
            var startDate = card.getAttribute('data-startdate');
            var endDate = card.getAttribute('data-enddate');
            var createdDate = card.getAttribute('data-createddate');
            var createdBy = card.getAttribute('data-createdby');
            var editedDate = card.getAttribute('data-editeddate');
            var editedBy = card.getAttribute('data-editedby');

            // Set modal content
            document.getElementById('modalJobName').textContent = jobName;
            document.getElementById('modalAppName').textContent = appName;
            document.getElementById('modalJobUrl').textContent = jobUrl;
            document.getElementById('modalJobInterval').textContent = jobInterval;
            document.getElementById('modalJobStatus').textContent = jobStatus;
            document.getElementById('modalDoNotification').textContent = doNotification;
            document.getElementById('modalDoNotificationEmail').textContent = doNotificationEmail;
            document.getElementById('modalDoNotificationEmailCC').textContent = doNotificationEmailCC;
            document.getElementById('modalDoNotificationEmailBCC').textContent = doNotificationEmailBCC;
            document.getElementById('modalRepeatUntilSuccess').textContent = repeatUntilSuccess;
            document.getElementById('modalLastRun').textContent = lastRun;
            document.getElementById('modalNextRun').textContent = nextRun;
            document.getElementById('modalStartDate').textContent = startDate;
            document.getElementById('modalEndDate').textContent = endDate;
            document.getElementById('modalCreatedDate').textContent = createdDate;
            document.getElementById('modalCreatedBy').textContent = createdBy;
            document.getElementById('modalEditedDate').textContent = editedDate;
            document.getElementById('modalEditedBy').textContent = editedBy;

            // Show the modal
            var modal = new bootstrap.Modal(document.getElementById('jobDetailsModal'));
            modal.show();
        });
    });
});
