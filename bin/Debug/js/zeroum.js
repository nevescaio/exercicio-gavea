
$('#combo').on('change', function() {
	var data = $.Deferred();
	var days = [
		'04/01/2016',
		'05/01/2016',
		'06/01/2016',
		'07/01/2016',
		'08/01/2016',
		'11/01/2016',
		'12/01/2016'
	];
	
	$('.container').removeClass('hidden');
	$('.container').addClass('show');
	if ($('html, body').scrollTop() < $('.jumbotron').height()){
		$('html, body').animate({
			scrollTop: $(".container").offset().top
		}, 1000);
	}
	

	$.get("/api/portfolio/"+this.value, function(response) {
		var cisneNegroHtml = zeroUmHtml = allHtml = '';
		for(var i = 0; i < response.cisneNegroAssets.length; i++) {
					cisneNegroHtml += '<tr><td>' + response.cisneNegroAssets[i].name + 
							'</td><td>' + response.cisneNegroAssets[i].number + 
							'</td><td class="text-right">' + parseFloat(response.cisneNegroAssets[i].money).toFixed(2) + '</td></tr>';
					zeroUmHtml += '<tr><td>' + response.zeroUmAssets[i].name + 
							'</td><td>' + response.zeroUmAssets[i].number + 
							'</td><td class="text-right">' + parseFloat(response.zeroUmAssets[i].money).toFixed(2) + '</td></tr>';
					allHtml += '<tr><td>' + response.allAssets[i].name + 
							'</td><td>' + response.allAssets[i].number + 
							'</td><td class="text-right">' + parseFloat(response.allAssets[i].money).toFixed(2) + '</td></tr>';
		}
		$('#cisneNegroTable tr').not(':first').remove();
		$('#zeroUmTable tr').not(':first').remove();
		$('#allTable tr').not(':first').remove();
		$('#cisneNegroTable tr').first().after(cisneNegroHtml);
		$('#zeroUmTable tr').first().after(zeroUmHtml);
		$('#allTable tr').first().after(allHtml);
		
		data.resolve(response);
	});
	
	$.when(data).done(function(data) {	
		$("#cisneNegroPieChart").CanvasJSChart({ 
			data: [ 
			{ 
				type: "pie", 
				showInLegend: false, 
				toolTipContent: "{label} <br/> R$ {y}",
				indexLabel:	"{label}",
				indexLabelPlacement: "inside",	
				indexLabelFontColor: "white",
				dataPoints: [ 
					{ label: data.cisneNegroAssets[0].name,  y: data.cisneNegroAssets[0].money },
					{ label: data.cisneNegroAssets[1].name,  y: data.cisneNegroAssets[1].money },
					{ label: data.cisneNegroAssets[2].name,  y: data.cisneNegroAssets[2].money },
					{ label: data.cisneNegroAssets[3].name,  y: data.cisneNegroAssets[3].money },
					{ label: data.cisneNegroAssets[4].name,  y: data.cisneNegroAssets[4].money },
					{ label: data.cisneNegroAssets[9].name,  y: data.cisneNegroAssets[9].money },
				] 
			} 
			] 
		});
		
		$("#zeroUmPieChart").CanvasJSChart({ 
			data: [ 
			{ 
				type: "pie", 
				showInLegend: false, 
				toolTipContent: "{label} <br/> R$ {y}",
				indexLabel:	"{label}",
				indexLabelPlacement: "inside",	
				indexLabelFontColor: "white",
				dataPoints: [ 
					{ label: data.zeroUmAssets[0].name,  y: data.zeroUmAssets[0].money },
					{ label: data.zeroUmAssets[1].name,  y: data.zeroUmAssets[1].money },
					{ label: data.zeroUmAssets[2].name,  y: data.zeroUmAssets[2].money },
					{ label: data.zeroUmAssets[3].name,  y: data.zeroUmAssets[3].money },
					{ label: data.zeroUmAssets[4].name,  y: data.zeroUmAssets[4].money },
					{ label: data.zeroUmAssets[9].name,  y: data.zeroUmAssets[9].money },
				] 
			} 
			] 
		});
		
		$("#allPieChart").CanvasJSChart({ 
			data: [ 
			{ 
				type: "pie", 
				showInLegend: false, 
				toolTipContent: "{label} <br/> R$ {y}",
				indexLabel:	"{label}",
				indexLabelPlacement: "inside",	
				indexLabelFontColor: "white",
				dataPoints: [ 
					{ label: data.allAssets[0].name,  y: data.allAssets[0].money },
					{ label: data.allAssets[1].name,  y: data.allAssets[1].money },
					{ label: data.allAssets[2].name,  y: data.allAssets[2].money },
					{ label: data.allAssets[3].name,  y: data.allAssets[3].money },
					{ label: data.allAssets[4].name,  y: data.allAssets[4].money },
					{ label: data.allAssets[9].name,  y: data.allAssets[9].money },
				] 
			} 
			] 
		});
		
		$("#cisneNegroGraph").CanvasJSChart({
			title: {
				text: "Evolução da cota"
			},
			axisY: {
				title: "Valor da cota (R$)",
				includeZero: false
			},
			axisX: {
				interval: 1
			},
			data: [
			{
				type: "line",
				toolTipContent: "{label}: R$ {y}",
				dataPoints: [
					{ label: days[0],  y: data.cisneNegroQuotas[0] },
					{ label: days[1],  y: data.cisneNegroQuotas[1] },
					{ label: days[2],  y: data.cisneNegroQuotas[2] },
					{ label: days[3],  y: data.cisneNegroQuotas[3] },
					{ label: days[4],  y: data.cisneNegroQuotas[4] },
					{ label: days[5],  y: data.cisneNegroQuotas[5] },
					{ label: days[6],  y: data.cisneNegroQuotas[6] },
				]
			}
			]
		});
		
		$("#zeroUmGraph").CanvasJSChart({
			title: {
				text: "Evolução da cota"
			},
			axisY: {
				title: "Valor da cota (R$)",
				includeZero: false
			},
			axisX: {
				interval: 1
			},
			data: [
			{
				type: "line",
				toolTipContent: "{label}: R$ {y}",
				dataPoints: [
					{ label: days[0],  y: data.zeroUmQuotas[0] },
					{ label: days[1],  y: data.zeroUmQuotas[1] },
					{ label: days[2],  y: data.zeroUmQuotas[2] },
					{ label: days[3],  y: data.zeroUmQuotas[3] },
					{ label: days[4],  y: data.zeroUmQuotas[4] },
					{ label: days[5],  y: data.zeroUmQuotas[5] },
					{ label: days[6],  y: data.zeroUmQuotas[6] },
				]
			}
			]
		});
	});
});