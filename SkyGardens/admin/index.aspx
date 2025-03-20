<%@ Page Title="" Language="C#" MasterPageFile="Admin.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="SkyGardens.index" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ContentPlaceHolderID="PageTitlePlaceholder" runat="server">
    <span class="dot blue"></span>
    Flowers database
</asp:Content>
<asp:Content ContentPlaceHolderID="MainContentPlaceholder" runat="server">
    <div class="constrained" x-data="{filtersOpen: false}">
        <h1>SKUs</h1>
        <p>
            Manage flower Stock Keeping Units (SKUs).
        </p>
        <asp:Button runat="server" Text="New SKU" ID="btn_newSKU" CssClass="blue" OnClick="btn_newSKU_Click" />
        <a href="#" @click="filtersOpen = !filtersOpen" x-text="filtersOpen ? 'Hide advanced search' : 'Show advanced search'" ></a>
        <div x-show="filtersOpen">
            <div class="fluid-flex filter-panel">

                <div>
                    <h3 style="margin: 0">Sort</h3>
                    <asp:DropDownList runat="server" ID="ddl_sort">
                        <asp:ListItem Text="Price: Low to High" Value="price" />
                        <asp:ListItem Text="Price: High to Low" Value="price DESC" />
                        <asp:ListItem Text="A-Z" Value="name" />
                        <asp:ListItem Text="Z-A" Value="name DESC" />
                        <asp:ListItem Text="Availability: Low to High" Value="stockLevel" />
                        <asp:ListItem Text="Availability: High to Low" Value="stockLevel DESC" />
                    </asp:DropDownList>
                </div>
                <div id="query">
                    <h3 style="margin: 0">Filter</h3>
                    <div>
                        <asp:CheckBox ID="ckb_priceFilter" runat="server" />
                        <span>Price</span>
                        <asp:DropDownList ID="ddl_priceFilter" runat="server">
                            <asp:ListItem Value=">" Text="greater than"></asp:ListItem>
                            <asp:ListItem Value="<" Text="less than"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:TextBox ID="txt_priceFilter" runat="server" TextMode="Number" step="0.01"></asp:TextBox>
                    </div>
                    <div>
                        <asp:CheckBox ID="ckb_discontinuedFilter" runat="server" />
                        <span>Exclude discontinued</span>
                    </div>
                    <div>
                        <asp:CheckBox ID="ckb_available" runat="server" />
                        <span>In stock</span>
                    </div>
                </div>
            </div>
            <asp:Button ID="btn_update" Text="Update results" runat="server" OnClick="btn_update_Click" />
        </div>
        <br />
        <br />
        <asp:CustomValidator CssClass="validator" ID="PriceValidator" runat="server" ErrorMessage="You have enabled a price filter. Please enter a price to compare against."></asp:CustomValidator>
    </div>
    <br />
    <br />
    <div class="skuHeader">
        <div class="constrained">
            <span class="skuName">Name
            </span>
            <div class="skuDetails">
                <span>Price</span>
                <span>Availability</span>
            </div>
        </div>
    </div>
    <asp:ListView runat="server" ID="lv_sku">
        <EmptyDataTemplate>
            <div class="constrained" style="background: #eee; padding: 7px 4px;">
                No items found. Please adjust your filters and try again.    
            </div>
        </EmptyDataTemplate>
        <ItemTemplate>
            <a href='flower.aspx?id=<%# Eval("id") %>' class="skuRow">
                <div class="constrained">
                    <span class="skuName">
                        <%# Eval("name") %>
                        <span class="pointer">&gt;</span>
                    </span>
                    <div class="skuDetails">
                        <span><%# Eval("price") %></span>
                        <span><%# int.Parse(Eval("stockLevel").ToString()) < 0 ? "No data" : Eval("stockLevel").ToString() %></span>
                        <span class="semi-transparent text-sm skuPropLabel">Price</span>
                        <span class="semi-transparent text-sm skuPropLabel">In stock</span>
                    </div>
                </div>
            </a>
        </ItemTemplate>
    </asp:ListView>
</asp:Content>
