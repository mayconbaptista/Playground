using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Data.Common;

// about this in: https://learn.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.diagnostics.idbconnectioninterceptor?view=efcore-8.0
namespace Efcore.Context;
public class ConnectionInterceptor : DbConnectionInterceptor
{
    #region "Connection Create"
    public override DbConnection ConnectionCreated(
                              ConnectionCreatedEventData connectionCreatedEventData,
                              DbConnection dbConnection)
    {
        Console.WriteLine("Connection is created");
        return base.ConnectionCreated(connectionCreatedEventData, dbConnection);
    }

    public override InterceptionResult<DbConnection> ConnectionCreating(
                                         ConnectionCreatingEventData connectionCreatingEventData,
                                         InterceptionResult<DbConnection> interceptionResult)
    {
        Console.WriteLine("Connection is created");
        return base.ConnectionCreating(connectionCreatingEventData, interceptionResult);
    }
    #endregion

    #region "Connection Open"
    public override void ConnectionOpened(
                   DbConnection connection,
                   ConnectionEndEventData eventData)
    {
        Console.WriteLine($"Connection is opened at:{DateTime.UtcNow}");
        base.ConnectionOpened(connection, eventData);
    }

    public override Task ConnectionOpenedAsync(
                   DbConnection connection,
                   ConnectionEndEventData eventData,
                   CancellationToken cancellationToken)
    {
        Console.WriteLine($"Connection is opened at:{DateTime.UtcNow}");
        return base.ConnectionOpenedAsync(connection, eventData, cancellationToken);
    }

    public override InterceptionResult ConnectionOpening(
                   DbConnection connection,
                   ConnectionEventData eventData,
                   InterceptionResult result)
    {
        Console.WriteLine("Connection is being opened");
        return base.ConnectionOpening(connection, eventData, result);
    }
    public override ValueTask<InterceptionResult> ConnectionOpeningAsync(
                   DbConnection connection,
                   ConnectionEventData eventData,
                   InterceptionResult result,
                   CancellationToken cancellationToken = default)
    {
        Console.WriteLine("Connection is being opened");
        return base.ConnectionOpeningAsync(connection, eventData, result, cancellationToken);
    }
    #endregion

    #region "Connection Close"
    public override void ConnectionClosed(
                              DbConnection connection,
                              ConnectionEndEventData eventData)
    {
        Console.WriteLine($"Connection closed at {DateTime.Now}");
        base.ConnectionClosed(connection, eventData);
    }
    public override Task ConnectionClosedAsync(
                              DbConnection connection,
                              ConnectionEndEventData eventData)
    {
        Console.WriteLine($"Connection closed at: {DateTime.UtcNow}");
        return base.ConnectionClosedAsync(connection, eventData);
    }

    public override InterceptionResult ConnectionClosing(
                          DbConnection connection,
                          ConnectionEventData eventData,
                          InterceptionResult result)
    {
        Console.WriteLine("Connection is being closed");
        return base.ConnectionClosing(connection, eventData, result);
    }
    public override ValueTask<InterceptionResult> ConnectionClosingAsync(
                   DbConnection connection,
                   ConnectionEventData eventData,
                   InterceptionResult result)
    {
        Console.WriteLine("Connection is being closed:");
        return base.ConnectionClosingAsync(connection, eventData, result);
    }
    #endregion

    #region "Connection Dispose"
    public override void ConnectionDisposed(
                          DbConnection connection,
                          ConnectionEndEventData eventData)
    {
        Console.WriteLine("Connection is disposed");
        base.ConnectionDisposed(connection, eventData);
    }

    public override Task ConnectionDisposedAsync(
                                 DbConnection connection,
                                 ConnectionEndEventData eventData)
    {
        Console.WriteLine("Connection is disposed");
        return base.ConnectionDisposedAsync(connection, eventData);
    }

    public override InterceptionResult ConnectionDisposing(
                                 DbConnection connection,
                                 ConnectionEventData eventData,
                                 InterceptionResult result)
    {
        Console.WriteLine("Connection is being disposed");
        return base.ConnectionDisposing(connection, eventData, result);
    }

    public override ValueTask<InterceptionResult> ConnectionDisposingAsync(
                                        DbConnection connection,
                                        ConnectionEventData eventData,
                                        InterceptionResult result)
    {
        Console.WriteLine("Connection is being disposed");
        return base.ConnectionDisposingAsync(connection, eventData, result);
    }
    #endregion
}
