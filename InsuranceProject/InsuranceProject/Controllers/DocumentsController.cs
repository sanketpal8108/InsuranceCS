using InsuranceDay1.Models;
using InsuranceProject.DTO;
using InsuranceProject.Exceptions;
using InsuranceProject.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;
using System.Xml.Linq;

namespace InsuranceProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentsController : ControllerBase
    {
        private IDocumentService _documentService;
        public DocumentsController(IDocumentService documentService)
        {
            _documentService = documentService;
        }
        [HttpGet("getAll")]
        public IActionResult Get()
        {
            var documentDTO = new List<DocumentsDto>();
            var documents = _documentService.GetAll();
            if (documents.Count > 0)
            {
                foreach (var document in documents)
                {
                    documentDTO.Add(ConvertToDTO(document));
                }
                return Ok(documentDTO);
            }
            throw new EntityNotFoundError("Documents not found");
        }
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var document = _documentService.Get(id);
            if (document == null)
            {
                throw new EntityNotFoundError("Documents not found");
            }
            return Ok(ConvertToDTO(document));
        }
        [HttpPost("Add")]
        public IActionResult Add(DocumentsDto documentDto)
        {
            var document = ConvertToModel(documentDto);
            var documentId = _documentService.Add(document);
            if (documentId == null)
                throw new EntityInsertError("Some errors Occurred");
            return Ok(documentId);
        }
        [HttpPut("Update")]
        public IActionResult Update(DocumentsDto documentDto)
        {
            var documentDTOToUpdate = _documentService.Check(documentDto.Id);
            if (documentDTOToUpdate != null)
            {
                var updatedDocument = ConvertToModel(documentDto);
                var modifiedDocument = _documentService.Update(updatedDocument);
                return Ok(ConvertToDTO(modifiedDocument));
            }
            throw new EntityNotFoundError("No Documents found to update");
        }
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var document = _documentService.Get(id);
            if (document != null)
            {
                _documentService.Delete(document);
                return Ok(id);
            }
            throw new EntityNotFoundError("No Documents found to delete");
        }
        [HttpPost("upload")]
        public IActionResult Upload([FromForm] DocumentsDto documentDto)
        {

            if (documentDto.File == null || documentDto.File.Length == 0)
            {
                return BadRequest("File is not selected or empty");
            }

            var documentModel = new Documents
            {
                DocumentType = documentDto.DocumentType,
                DocumentName = documentDto.DocumentName,
                CustomerId = documentDto.CustomerId,
                IsApproved=false,
                IsActive=true,
                //Status = "Pending"

                //  DocumentName = documentDto.File.FileName // save the file name
                // set other properties
            };

            using (var memoryStream = new MemoryStream())
            {
                documentDto.File.CopyTo(memoryStream);
                documentModel.File = memoryStream.ToArray(); // save the file content
            }

            int id = _documentService.Add(documentModel);
            if (id != 0)
            {
                return Ok(id);
            }
            throw new EntityInsertError("Some issue while adding the document");
        }
        private Documents ConvertToModel(DocumentsDto documentDto)
        {
            return new Documents()
            {
                Id = documentDto.Id,
                DocumentType = documentDto.DocumentType,

                //DocumentInformation = documentDto.DocumentInformation,
                DocumentName = documentDto.DocumentName,
                CustomerId = documentDto.CustomerId,
                //CustomerId= documentDto.CustomerId,
                IsActive = true,
                File=documentDto.ViewDocument,
                IsApproved=documentDto.IsApproved
            };
        }
        private DocumentsDto ConvertToDTO(Documents document)
        {
            return new DocumentsDto()
            {
                Id = document.Id,
                DocumentType = document.DocumentType,
                DocumentName = document.DocumentName,
                ViewDocument=document.File,
                //DocumentInformation = document.DocumentInformation,
                CustomerId = document.CustomerId,
                IsApproved=document.IsApproved
            };
        }
    }
}
