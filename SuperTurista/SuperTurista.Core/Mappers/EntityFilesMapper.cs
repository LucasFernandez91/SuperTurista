using SuperTurista.Core.DTOs;
using SuperTurista.Core.Helpers;
using SuperTurista.Core.Models;
using System;

namespace SuperTurista.Core.Mappers
{
    public class EntityFilesMapper
    {
        public EntityFiles MapToEntityFiles(SaveEntityFilesDTO DTO)
        {
            return new EntityFiles()
            {
                Id = DTO.Id,
                FilePath = DTO.FilePath,
                FileExtension = DTO.FileExtension,
                FileName = DTO.FileName,
            };
        }
        public EntityFilesDTO MapToDto(EntityFiles entity)
        {
            return new EntityFilesDTO()
            {
                Id = entity.Id,
                FilePath = entity.FilePath,
                FileExtension = entity.FileExtension,
                FileName = entity.FileName,
            };
        }
    }
}
