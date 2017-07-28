using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System.Collections;

// For more information about this template visit http://aka.ms/azurebots-csharp-basic
[Serializable]
public class EchoDialog : IDialog<object>
{
    protected int count = 1;

    public Task StartAsync(IDialogContext context)
    {
        try
        {
            context.Wait(MessageReceivedAsync);
        }
        catch (OperationCanceledException error)
        {
            return Task.FromCanceled(error.CancellationToken);
        }
        catch (Exception error)
        {
            return Task.FromException(error);
        }

        return Task.CompletedTask;
    }

    public virtual async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> argument)
    {
        var message = await argument;
        /*
        if (message.Text == "reset")
        {
            PromptDialog.Confirm(
                context,
                AfterResetAsync,
                "Are you sure you want to reset the count?",
                "Didn't get that!",
                promptStyle: PromptStyle.Auto);
        }
        else
        {
            await context.PostAsync($"{this.count++}: You said {message.Text}");
            context.Wait(MessageReceivedAsync);
        }
        */

        if (message.Text.ToUpper().Contains("ILITRI"))
        {
            await context.PostAsync(ObtenerFrase());
            context.Wait(MessageReceivedAsync);
        }
    }

    public async Task AfterResetAsync(IDialogContext context, IAwaitable<bool> argument)
    {
        var confirm = await argument;
        if (confirm)
        {
            this.count = 1;
            await context.PostAsync("Reset count.");
        }
        else
        {
            await context.PostAsync("Did not reset count.");
        }
        context.Wait(MessageReceivedAsync);
    }

    public string ObtenerFrase()
    {
        ArrayList<string> list = new ArrayList();
        list.Add("Viva ROTO2");
        list.Add("Tengo los 30cms reglamentarios");
        list.Add("Valla no me lo experava");
        list.Add("xD es broma no te rayes");
        list.Add("Pero que me estas container");
        list.Add("Me hase enfureser");
        list.Add("Virgensita de guadalupe");
        list.Add("pues eso que e vajao esta mañana y me encuentro con las 2 puertas como si fuera un abre latas y mi sorpresa¡¡¡¡¡la radio del coche no esta joder si la deje devajo escondia y no mea podio ver nadie miro por todo el coche y encima meloan arañao entero,bien el seguro lo tengo la poliza 10 que entra robo y el robo del radio casset tanbien asta un valor de 200e y mi duda es si me entrara tanbien todo los arañazos que mean echo? ayuda¡¡¡¡¡¡¡¡");
        list.Add("A mi no me preguntes, solo soy una chica jijiji");
        list.Add("Este tema sin fotos no vale nada");
        list.Add("Hola, soy nuevo y no me ubico muxo en esto de los fors, queria saber si alguien sabe como construir una dobladora d etubos(pipe bender), vi que un integrante del foro tenia una antigua, me gustatia saber si puede compartir las dimensiones(un planito), lo d ela bomba se cambia por una gata hidraulica y listo. Gracias de antemano y muy buen foro");

        Random random = new Random();
        int total = list.Count;
        int randomNumber = random.Next(0, total);

        return list[randomNumber];
    }
}