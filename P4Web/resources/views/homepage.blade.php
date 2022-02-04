@extends('layouts.layout')
@section('title')
    {{ __('Homepage') }}
@endsection
@section('content')
    <body class="antialiased">
        <div>
            <?php $x=1;?>
            @foreach($pizzas as $pizza)
                <div style="margin: 10px">
                    <a href="/menu-item/{{{$x++}}}">{{$pizza->pizza_name}}</a>
                </div>
            @endforeach
        </div>
    </body>
@endsection
