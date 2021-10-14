using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using NossoQueijo.Aplicacao;
using NossoQueijo.Dominio.Interfaces.Aplicacao;
using NossoQueijo.Dominio.Interfaces.Repositorio;
using NossoQueijo.Repositorio.RepositoriosEF;
using System;

namespace NossoQueijo.WebAPI
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Cidade
            services.AddTransient<ICidadeAplicacao, CidadeAplicacao>();
            services.AddTransient<ICidadeRepositorio, CidadeRepositorio>();

            // Endereco
            services.AddTransient<IEnderecoAplicacao, EnderecoAplicacao>();
            services.AddTransient<IEnderecoRepositorio, EnderecoRepositorio>();

            // Estado
            services.AddTransient<IEstadoAplicacao, EstadoAplicacao>();
            services.AddTransient<IEstadoRepositorio, EstadoRepositorio>();

            // EstoquePorData
            services.AddTransient<IEstoquePorDataAplicacao, EstoquePorDataAplicacao>();
            services.AddTransient<IEstoquePorDataRepositorio, EstoquePorDataRepositorio>();

            // FichaProducao
            services.AddTransient<IFichaProducaoAplicacao, FichaProducaoAplicacao>();
            services.AddTransient<IFichaProducaoRepositorio, FichaProducaoRepositorio>();

            // FormaPagamento
            services.AddTransient<IFormaPagamentoAplicacao, FormaPagamentoAplicacao>();
            services.AddTransient<IFormaPagamentoRepositorio, FormaPagamentoRepositorio>();

            // Pedido
            services.AddTransient<IPedidoAplicacao, PedidoAplicacao>();
            services.AddTransient<IPedidoRepositorio, PedidoRepositorio>();

            // PedidoProduto
            services.AddTransient<IPedidoProdutoAplicacao, PedidoProdutoAplicacao>();
            services.AddTransient<IPedidoProdutoRepositorio, PedidoProdutoRepositorio>();

            // Produto
            services.AddTransient<IProdutoAplicacao, ProdutoAplicacao>();
            services.AddTransient<IProdutoRepositorio, ProdutoRepositorio>();

            // Status
            services.AddTransient<IStatusAplicacao, StatusAplicacao>();
            services.AddTransient<IStatusRepositorio, StatusRepositorio>();

            // TipoUsuario
            services.AddTransient<ITipoUsuarioAplicacao, TipoUsuarioAplicacao>();
            services.AddTransient<ITipoUsuarioRepositorio, TipoUsuarioRepositorio>();

            // Usuario
            services.AddTransient<IUsuarioAplicacao, UsuarioAplicacao>();
            services.AddTransient<IUsuarioRepositorio, UsuarioRepositorio>();

            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  builder =>
                                  {
                                      builder.WithOrigins("http://localhost:8101/",
                                                          "http://localhost:8101",
                                                          "https://localhost:8101/",
                                                          "https://localhost:8101",
                                                          "http://localhost:8100/",
                                                          "http://localhost:8100",
                                                          "https://localhost:8100/",
                                                          "https://localhost:8100")
                                      .AllowAnyHeader()
                                      .AllowAnyMethod();
                                  });
            });

            services.AddControllers()
                .AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddControllers();

            services.AddSwaggerGen(c => {

                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "NossoQueijo",
                        Version = "v1",
                        Description = "E-commerce de queijos",
                        Contact = new OpenApiContact
                        {
                            Name = "Humberto Júnior",
                            Url = new Uri("https://github.com/tiroberto")
                        }
                    });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
             
            // Ativando middlewares para uso do Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "NossoQueijo");
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(MyAllowSpecificOrigins);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
