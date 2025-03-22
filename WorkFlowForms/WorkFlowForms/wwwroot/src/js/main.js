document.addEventListener('DOMContentLoaded', function() {
    const requirementFormLink = document.getElementById('requirementForm');
    const systemRequirementForm = document.getElementById('systemRequirementForm');

    requirementFormLink.addEventListener('click', function(e) {
        e.preventDefault();
        systemRequirementForm.classList.remove('hidden');
    });

    systemRequirementForm.addEventListener('submit', function(e) {
        e.preventDefault();
        const formData = new FormData(this);
        // 這裡添加產生Word文件的邏輯
        console.log('表單提交', Object.fromEntries(formData));
    });
}); 