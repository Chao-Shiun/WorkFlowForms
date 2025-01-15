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
        string filePath = Path.Combine(baseDirectory, "Doc", "doc1.docx");
        
        // 確認檔案是否存在
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException("檔案不存在", filePath);
        }

        // 打開文檔
        using DocX document = DocX.Load(filePath);
        // 根據 Doc1Dto 的內容更新文檔
        // 例如：document.ReplaceText("{Placeholder}", doc1Dto.SomeProperty);

        // 保存更新後的文檔到 MemoryStream
        using MemoryStream stream = new MemoryStream();
        document.SaveAs(stream);
        return stream.ToArray(); // 返回文檔的 byte array
    }
}