using WorkFlowForms.Common.Model.Dto;

namespace WorkFlowForms.Service.Interface;


public interface IDocService
{
    byte[] ProcessDoc(Doc1Dto doc1Dto);
}