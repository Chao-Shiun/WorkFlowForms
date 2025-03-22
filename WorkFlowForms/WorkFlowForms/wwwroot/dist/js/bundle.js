/******/ (() => { // webpackBootstrap
/*!************************!*\
  !*** ./src/js/main.js ***!
  \************************/
document.addEventListener('DOMContentLoaded', function () {
  const requirementFormLink = document.getElementById('requirementForm');
  const testReportLink = document.getElementById('testReport');
  const boardChangeLink = document.getElementById('boardChange');
  const systemRequirementForm = document.getElementById('systemRequirementForm');
  const formContainer = document.getElementById('formContainer');

  // RPA和個資相關元素
  const rpaNoRadio = document.getElementById('rpaNo');
  const rpaYesRadio = document.getElementById('rpaYes');
  const personalDataNoRadio = document.getElementById('personalDataNo');
  const personalDataYesRadio = document.getElementById('personalDataYes');
  const personalDataSection = document.getElementById('personalDataSection');

  // 點擊左側選單項目事件
  requirementFormLink.addEventListener('click', function (e) {
    e.preventDefault();
    systemRequirementForm.classList.remove('hidden');
  });

  // RPA選項變更事件
  rpaNoRadio.addEventListener('change', function () {
    if (this.checked) {
      personalDataNoRadio.checked = true;
      personalDataSection.classList.add('disabled');
      // 自動將下方相關欄位設為disabled
    }
  });
  rpaYesRadio.addEventListener('change', function () {
    if (this.checked) {
      // 仍然需要檢查個資選項
      if (personalDataYesRadio.checked) {
        personalDataSection.classList.remove('disabled');
      }
    }
  });

  // 個人資料選項變更事件
  personalDataNoRadio.addEventListener('change', function () {
    if (this.checked) {
      personalDataSection.classList.add('disabled');
    }
  });
  personalDataYesRadio.addEventListener('change', function () {
    if (this.checked && rpaYesRadio.checked) {
      personalDataSection.classList.remove('disabled');
    }
  });

  // 表單提交事件
  systemRequirementForm.addEventListener('submit', function (e) {
    e.preventDefault();
    const formData = new FormData(this);
    console.log('表單提交', Object.fromEntries(formData));
  });
});
/******/ })()
;
//# sourceMappingURL=bundle.js.map