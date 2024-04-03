using PecezuelosDTO;
using PecezuelosWebAssembly.Servicios.Contrato;
using System.Net.Http.Json;
using Blazored.LocalStorage;
using Blazored.Toast;
using Blazored.Toast.Services;

namespace PecezuelosWebAssembly.Servicios.Implementacion
{
    public class CarritoServicio : ICarritoServicio
    {
        private ILocalStorageService _localStorageService;
        private ISyncLocalStorageService _localSyncStorageService;
        private IToastService _toastService;


        public CarritoServicio(ILocalStorageService localStorageService, ISyncLocalStorageService localSyncStorageService, IToastService toastService)
        {
            _localStorageService = localStorageService;
            _localSyncStorageService = localSyncStorageService;
            _toastService = toastService;
        }

        public event Action MostrarItems;

        public async Task AgregarCarrito(CarritoDTO carrito)
        {
            try 
            {
                var carritos = await _localStorageService.GetItemAsync<List<CarritoDTO>>("carrito");

                if (carritos == null)
                    carritos = new List<CarritoDTO>();

                var encontrardo = carritos.FirstOrDefault(c => c.Producto.IdProducto == carrito.Producto.IdProducto);

                if (encontrardo != null)
                    carritos.Remove(encontrardo);

                carritos.Add(carrito);

                await _localStorageService.SetItemAsync("carrito", carritos);

                if (encontrardo != null)
                    _toastService.ShowSuccess("El producto fue actualizado en carrito");
                else
                    _toastService.ShowSuccess("El producto fue agregado al carrito");

                MostrarItems.Invoke();
            }
            catch 
            {
                _toastService.ShowError("No se pudo agregar al carrito");
            }
        }

        public int CantidadProductos()
        {
            var carrito = _localSyncStorageService.GetItem<List<CarritoDTO>>("carrito");

            return carrito == null? 0 : carrito.Count();


        }

        public async Task<List<CarritoDTO>> DevolverCarrito()
        {
            var carrito = await _localStorageService.GetItemAsync<List<CarritoDTO>>("carrito");

            if (carrito == null)
                carrito = new List<CarritoDTO>();

            return carrito;
        }

        public async Task EliminarCarrito(int Id)
        {
            try 
            {
                var carrito = await _localStorageService.GetItemAsync<List<CarritoDTO>>("carrito");

                if (carrito != null)
                { 
                    var elemento = carrito.FirstOrDefault(c => c.Producto.IdProducto == Id);

                    if (elemento != null)
                        carrito.Remove(elemento);
                    await _localStorageService.SetItemAsync("carrito", carrito);

                    MostrarItems.Invoke();

                }
            }
            catch 
            {
                
            }
        }

        public async Task LimpiarCarrito()
        {
            await _localStorageService.RemoveItemAsync("carrito");
            MostrarItems.Invoke();
        }
    }
}
