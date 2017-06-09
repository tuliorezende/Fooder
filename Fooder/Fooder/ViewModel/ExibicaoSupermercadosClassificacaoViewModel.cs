﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyChanged;
using System.Collections.ObjectModel;
using Fooder.Model;
using System.Windows.Input;
using Xamarin.Forms;
using Fooder.ExternalService;

namespace Fooder.ViewModel
{
    [ImplementPropertyChanged]
    public class ExibicaoSupermercadosClassificacaoViewModel
    {
        public ObservableCollection<ClassificacaoMercados> ListaClassificacaoSupermercados { get; set; }
        public ObservableCollection<Lista> LstMercados { get; set; }
        public ICommand BuscarElementos { get; set; }
        public ICommand RedirecionarMapa { get; set; }
        public Lista ListaSelecionada { get; set; }
        public ExibicaoSupermercadosClassificacaoViewModel()
        {
            try
            {
                BuscarElementos = new Command(() => BuscarClassificacao());
                //RedirecionarMapa = new Command<ClassificacaoMercados>((key) => TelaDetalhesProduto(key));
                //RedirecionarMapa = new Command<ClassificacaoMercados>(TelaDetalhesProduto);

                LstMercados = new ObservableCollection<Lista>(App.Database.Lista_GetItemsAsync().Result);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        private async void BuscarClassificacao()
        {
            try
            {
                ListaClassificacaoSupermercados = await FooderService.RetornaClassificacoes(await App.Database.ProdutoLista_GetItemsAsync(ListaSelecionada.CodigoLista));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void TelaDetalhesProduto(ClassificacaoMercados mercados)
        {
            try
            {
                var a = mercados.UrlMapa;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
