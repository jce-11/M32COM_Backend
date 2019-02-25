﻿using M32COM_Backend.DTOs;
using M32COM_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace M32COM_Backend.Mappers
{
	public static class GenericMapper
	{
		public static UserDTO MapToUserDTO(User user)
		{
			return new UserDTO
			{
				id = user.id,
				name = user.name,
				surname = user.surname,
				email = user.email,
				teamName = user.team == null ? "" : user.team.name
			};
		}

		public static LoginResponseDTO MapToLoginResponseDTO(User user,string token)
		{
			return new LoginResponseDTO
			{
				id = user.id,
				name = user.name,
				surname = user.surname,
				email = user.email,
				teamName = user.team == null ? "" : user.team.name,
				token = token

			};


		}


		public static TeamDTO MapToTeamDTO(Team team)
		{
			TeamDTO teamDTO = new TeamDTO()
			{
				id = team.id,
				leaderId = team.leaderId,
				name = team.name
			};

			foreach(User u in team.teamMembers)
			{
				teamDTO.teamMembers.Add(MapToUserDTO(u));
			}
			return teamDTO;
		}

		public static BoatDTO MapToBoatDTO(Boat boat)
		{
			return new BoatDTO
			{
				id = boat.id,
				model = boat.model,
				year = boat.year,
				teamName = boat.team.name
			};
		}

		public static NotificationDTO MapToNotificationDTO(Notification notification)
		{
			return new NotificationDTO
			{
				id = notification.id,
				sentById = notification.sentById,
				sentByNameSurname = notification.sentBy.name + " " + notification.sentBy.surname,
				receivedById = notification.receivedById,
				receivedByNameSurname = notification.receivedBy.name + " " + notification.receivedBy.surname,
				actionToken = notification.actionToken,
				description = notification.description,
				sentTime = notification.sentTime
			};
		}
	}
}