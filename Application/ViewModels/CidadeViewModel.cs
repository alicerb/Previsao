using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PrevisaoTempo.Application.ViewModels
{
    public class CidadeViewModel
    {
        public CidadeViewModel()
        {
            
        }

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Preencha o campo Nome")]
        [MaxLength(150, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        public string Nome { get; set; }

       [ScaffoldColumn(false)]
        public int OpenWeatherId { get; set; }

        public bool Sucesso { get; set; }
        public string Mensagem { get; set; }

        
    }
}