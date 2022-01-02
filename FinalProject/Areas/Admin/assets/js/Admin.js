$('#submenu_account').hide();
$('input[type="text"]');

var show_menu = true;
$(".btn_account").on('click', function(){
	if(show_menu == true){
		$('#submenu_account').show('slow');
		show_menu = false;
	}else{
		$('#submenu_account').hide('slow');
		show_menu = true;
	}
});
$('#form_insert').validate({
	rules : {
		fullname: 'required',
		username: {
			required: true,
			email: true
		}
	},
	messages: {
		fullname: 'Vui lòng nhập họ tên',
		username: {
			required: 'Vui lòng nhập tài khoản',
			email: 'Vui lòng nhập đúng định dạng email'
		}
	}
});

