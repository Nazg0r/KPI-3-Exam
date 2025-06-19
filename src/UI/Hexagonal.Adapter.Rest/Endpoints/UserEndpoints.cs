using Hexagonal.Application.Commands;
using Hexagonal.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hexagonal.Adapter.Rest.Endpoints
{
	public static class UserEndpoints
	{
		public static void MapUserEndpoints(this IEndpointRouteBuilder app)
		{
			app.MapGet("/api/user/{id}", async (
				string id,
				[FromServices] ISender sender,
				CancellationToken cancellationToken) =>
			{
				var query = new GetUserByIdQuery(id);
				var user = await sender.Send(query, cancellationToken);
				return Results.Ok(user);
			});

			app.MapGet("/api/user", async (
				[FromBody] GetUserByEmailQuery query,
				[FromServices] ISender sender,
				CancellationToken cancellationToken) =>
			{
				var user = await sender.Send(query, cancellationToken);
				return Results.Ok(user);
			});

			app.MapDelete("/api/user/{id}", async (
				string id,
				[FromServices] ISender sender,
				CancellationToken cancellationToken) =>
			{
				var command = new DeleteUserCommand(id);
				await sender.Send(command, cancellationToken);
				return Results.NoContent();
			});

			app.MapPost("/api/user", async (
				[FromBody] CreateUserCommand command,
				[FromServices] ISender sender,
				CancellationToken cancellationToken) =>
			{
				var user = await sender.Send(command, cancellationToken);
				return Results.Created($"/api/user/{user.Id}", user);
			});

			app.MapPut("/api/user", async (
				[FromBody] UpdateUserCredentialsCommand command,
				[FromServices] ISender sender,
				CancellationToken cancellationToken) =>
			{
				var user = await sender.Send(command, cancellationToken);
				return Results.Ok(user);
			});
		}
	}
}