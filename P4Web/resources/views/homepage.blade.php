@extends('layouts.layout')
@section('title')
    {{ __('Homepage') }}
@endsection
@section('content')
    <body class="antialiased">
        <div style="display: flex;">
            <div style="border: 2px solid black; margin:10px;">
                <?php $x=0; ?>
                @foreach($pizzas as $pizza)
                        <a href="/orders/{{$pizza->id}}">
                            <div style="border:2px solid black; margin:2px; min-height:50px; width: 200px">
                                {{$pizza->pizza_name}}
                            </div>
                        </a>
                @endforeach
            </div>
            <div style="border: 2px solid black;">
                <a href="/orders/{{}}">
                    <button>order</button>
                </a>
            </div>
        </div>
    </body>
@endsection
