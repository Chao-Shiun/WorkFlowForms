using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WorkFlowForms.Common.Model.ViewModel;
using WorkFlowForms.Common.Model.Dto;
using WorkFlowForms.Service.Interface;

namespace WorkFlowForms.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DocController(IMapper mapper, IDocService docService) : ControllerBase
    {
        [HttpPost]
        public IActionResult CreateForm(Doc1ViewModel doc1ViewModel)
        {
            var doc1Dto = mapper.Map<Doc1Dto>(doc1ViewModel);
            // 將Dto傳遞給Service層並獲取文件的byte[]
            var fileContent = docService.ProcessDoc(doc1Dto);

            // 設定文件的MIME類型和文件名
            var contentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
            var fileName = "系統申請需求確認書.docx"; // 根據實際情況設置文件名

            // 返回文件
            return File(fileContent, contentType, fileName);
        }
    }
} 