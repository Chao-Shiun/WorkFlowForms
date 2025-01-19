using System.IO;
using Xceed.Words.NET;
using WorkFlowForms.Common.Model.Dto;
using WorkFlowForms.Service.Interface;

namespace WorkFlowForms.Service;

public class DocService : IDocService
{
    public byte[] ProcessDoc(Doc1Dto doc1Dto)
    {
        // 使用 AppContext.BaseDirectory 來構建路徑
        string baseDirectory = AppContext.BaseDirectory;
        string filePath = Path.Combine(baseDirectory, "Doc", "系統申請需求確認書.docx");
        
        // 確認檔案是否存在
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException("檔案不存在", filePath);
        }

        // 打開文檔
        using DocX document = DocX.Load(filePath);
        // 根據 Doc1Dto 的內容更新文檔
        // 例如：document.ReplaceText("{Placeholder}", doc1Dto.SomeProperty);
        document.ReplaceText("{{Year}}", doc1Dto.Year);
        document.ReplaceText("{{Month}}", doc1Dto.Month);
        document.ReplaceText("{{Day}}", doc1Dto.Day);
        document.ReplaceText("{{RequestingUnit}}", doc1Dto.RequestingUnit);
        document.ReplaceText("{{ContactPerson}}", doc1Dto.ContactPerson);
        document.ReplaceText("{{ExtensionNumber}}", doc1Dto.ExtensionNumber);
        document.ReplaceText("{{RelevantDepartments}}", doc1Dto.RelevantDepartments);
        document.ReplaceText("{{SystemName}}", doc1Dto.SystemName);
        document.ReplaceText("{{Requirements}}", doc1Dto.Requirements);
        document.ReplaceText("{{FeatureDevelopmentDescription}}", doc1Dto.FeatureDevelopmentDescription);
        document.ReplaceText("{{EstimatedWorkingHours}}", doc1Dto.EstimatedWorkingHours);
        document.ReplaceText("{{EstimatedDeliveryDate}}", doc1Dto.EstimatedDeliveryDate);
        document.ReplaceText("{{EstimatedGoLiveDate}}", doc1Dto.EstimatedGoLiveDate);
        document.ReplaceText("{{DevelopmentEvaluator}}", doc1Dto.DevelopmentEvaluator);
        document.ReplaceText("{{DevelopmentEvaluatorExtensionNumber}}", doc1Dto.DevelopmentEvaluatorExtensionNumber);
        

        // 保存更新後的文檔到 MemoryStream
        using MemoryStream stream = new MemoryStream();
        document.SaveAs(stream);
        return stream.ToArray(); // 返回文檔的 byte array
    }
}