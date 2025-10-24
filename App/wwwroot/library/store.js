(function ($) {
    var KT = {};
    KT.GetBrand = async () => {
        const response = await fetch('/api/v1/product/brands');
        const data = await response.json();
        if (response.ok && data.success) {
            const typeSelect = $('select[name="Product.BrandId"]');
            typeSelect.empty();
            typeSelect.append('<option value="0">-- Chọn loại sản phẩm --</option>');

            data.data.forEach(type => {
                typeSelect.append(`<option value="${type.brandId}">${type.brandName}</option>`);
            });
        }
    }
    KT.GetType = async () => {
        const response = await fetch('/api/v1/product/types');
        const data = await response.json();
        if (response.ok && data.success) {
            const typeSelect = $('select[name="Product.TypeId"]');
            typeSelect.empty();
            typeSelect.append('<option value="0">-- Chọn loại sản phẩm --</option>');

            data.data.forEach(type => {
                typeSelect.append(`<option value="${type.typeId}">${type.typeName}</option>`);
            });
        }
    }
    KT.addBrand = () => {
        $('#form3').on('submit', async function (e) {
            e.preventDefault();
            $('#brandSuccess').text('');
            const brandName = $('#brandName').val().trim();
            const response = await fetch('/api/v1/product/store/brand', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({
                    BrandName: brandName
                })
            });

            const data = await response.json();

            if (response.ok && data.success) {
                $('#brandSuccess').text(data.message);
                $('#brandName').val('');
                KT.GetBrand();
            }
        });
    }

    KT.addType = () => {
        $('#form2').on('submit', async function (e) {
            e.preventDefault();
            $('#typeSuccess').text('');
            const typeName = $('#typeName').val().trim();
            const response = await fetch('/api/v1/product/store/type', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({
                    TypeName: typeName
                })
            });

            const data = await response.json();
            if (response.ok && data.success) {
                $('#typeSuccess').text(data.message);
                $('#typeName').val('');
                KT.GetType();
            }
        });
    }

    $(document).ready(function () {
        KT.addBrand();
        KT.addType();
    });

})(jQuery);